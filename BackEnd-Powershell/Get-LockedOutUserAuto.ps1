param (
    [string]$FilePath = "C:\LocalFolder",
    [string]$DomainName = "YouDomainName.com",
    [int]$CSVRetention = "90",
    $FileName = $null,
    $TempFileName = $null,
    [array]$NewValue = $null,
    [array]$NewFileData = $null,
    [string]$UserName = "*",
    [datetime]$Today = (Get-Date -Format MM-dd-yy),
    [datetime]$StartTime = (Get-Date).AddDays(-3)    
)

$FileName = "Security-Events_$($Today.ToString('MM-dd-yy')).csv"
$TempFileName = "Temp_Security-Events_$($Today.ToString('MM-dd-yy')).csv"

$Forest = [system.directoryservices.activedirectory.Forest]::GetCurrentForest()
$DC = $Forest.domains | ForEach-Object {$_.DomainControllers} | ForEach-Object {$_.Name}

sleep 1


Write-Host "`nScript will search for locked out events on the following domain controllers..." -BackgroundColor Gray -ForegroundColor Black
$dc


"`n"

$dc | foreach {
    
    
    "Querying " + $_

    $ErrorActionPreference = "SilentlyContinue"
    Get-WinEvent -ComputerName $_ -FilterHashtable @{LogName='Security';Id=4740;StartTime=$StartTime} |
        Where-Object {$_.Properties[0].Value -like "$UserName"} |
        Select-Object -Property TimeCreated, 
            @{Label='UserName';Expression={$_.Properties[0].Value}},
            @{Label='ClientName';Expression={$_.Properties[1].Value}} |    
        Select-Object -Property 'TimeCreated', 'UserName', 'ClientName'|
        Export-Csv -Path "$FilePath\$TempFileName" -Append -NoTypeInformation

    $ErrorActionPreference = "Continue"

}

"`nQuerying PDC server for archived events..."
[System.DirectoryServices.ActiveDirectory.Domain]::GetDomain((
            New-Object System.DirectoryServices.ActiveDirectory.DirectoryContext('Domain', $DomainName))
        ).PdcRoleOwner.name



 Invoke-Command (

    [System.DirectoryServices.ActiveDirectory.Domain]::GetDomain((
        New-Object System.DirectoryServices.ActiveDirectory.DirectoryContext('Domain', $DomainName))
    ).PdcRoleOwner.name

) { 
        
    Get-ChildItem "C:\windows\system32\winevt\logs\Archive-Security*" -Recurse| foreach {        
        Write-Host "`nSearching in event FileName:"$_.Name  -BackgroundColor Gray -ForegroundColor Black
        Get-WinEvent -FilterHashtable @{path=$_.fullname;Logname="Security";Id=4740;StartTime=$Using:StartTime} |
        Where-Object {$_.Properties[0].Value -like "$Using:UserName"} |
        Select-Object -Property TimeCreated, 
            @{Label='UserName';Expression={$_.Properties[0].Value}},
            @{Label='ClientName';Expression={$_.Properties[1].Value}}
    }
        
} | Select-Object -Property TimeCreated, 'UserName', 'ClientName' |  Export-Csv -Path "$FilePath\$TempFileName" -Append -NoTypeInformation


"`nGetting rid of duplicate vaules..."
$FileData = Import-Csv -Path "$FilePath\$TempFileName" | Sort-Object timecreated, username, clientname -Unique | sort {$_.timecreated -as [datetime]} -Descending


"`nSorting entries as per date...`n"
$FileData | %{
    
    [datetime]$NewTime = $_.timecreated
    $NewFileName = "Security-Events_$($NewTime.ToString('MM-dd-yy')).csv"

    
    if (Test-Path "$FilePath\$NewFileName") {
        $NewFileData = Import-Csv "$FilePath\$NewFileName"
    }

    if ($NewTime -ge $Today) {
        "Entry for today"
        ("-" * "Entry for today".Length)
        ($_ | ft -HideTableHeaders | Out-String).trim()
        "`n"
        [array]$FileDataT += $_
    }
    else {
        if (Test-Path -Path "$FilePath\$NewFileName") {
            "Entry should be in $NewFileName"
            ("-" * "Entry should be in $NewFileName".Length)
            ($_ | ft -HideTableHeaders| Out-String).trim()
            "`n"
            $NewFileData += $_
        }
        else {
            "Entry should be in New file $NewFileName"
            ("-" * "Entry should be in New file $NewFileName".Length)
            ($_ | ft -HideTableHeaders| Out-String).trim()
            `n
            $NewFileData += $_
        }
        $NewFileData = $NewFileData | Sort-Object timecreated, username, clientname -Unique | sort {$_.timecreated -as [datetime]} -Descending
        $NewFileData | Export-Csv -Path "$FilePath\$NewFileName" -NoTypeInformation -Force -Confirm:$false
    } 
}


$FileDataT | Export-Csv -Path "$FilePath\$FileName" -NoTypeInformation


sleep 5
"Removing Temporary files"
Remove-Item "$FilePath\$TempFileName" -Force -Confirm:$false

"Removing files older than $CSVRetention"
Get-ChildItem –Path $FilePath\*.csv -Recurse -File  | Where-Object {($_.LastWriteTime -lt (Get-Date).AddDays(-$CSVRetention))} | Remove-Item -Confirm:$false -Force -Verbose
