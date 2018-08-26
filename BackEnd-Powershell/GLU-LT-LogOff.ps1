$LineSize = $null
$LineSize = (get-host).ui.rawui.windowsize.width
if ($LineSize -eq $null -or !$LineSize) {$LineSize = "50"}

$SessionList = $NULL
$queryResults = $NULL
$SError = $null
$AqueryResults = $null

# Import the Active Directory module for the Get-ADComputer CmdLet
Import-Module ActiveDirectory


if (Test-Connection $ServerName -Count 1 -Quiet) {
    Write-Output "`n`n`n$ServerName is online!"
    Write-Output ("-" * $LineSize)

    Write-Output ("Querying Server: `"$ServerName`" for disconnected sessions under UserName: `"" + $UserName.ToUpper() + "`"...")
    

            query user $UserName /server:$ServerName 2>&1 | foreach {

            if ($_ -match "Disc") {
                $queryResults = write-output ("`n$ServerName," + (($_.trim() -replace ' {2,}', ',')))
            }
            elseif ($_ -match "Active") {
                $AqueryResults = write-output ("`n$ServerName," + (($_.trim() -replace ' {2,}', ',')))
            }
            elseif ($_ -match "The RPC server is unavailable") {
                [array]$SError += ($ServerName)
                Write-Output "Unable to query the $ServerName, check for firewall settings on $ServerName!"
            }
            elseif ($_ -match "No User exists for") {Write-Output "No user session exists"}
        }
    
}
else {

    Write-Output "`n`n`n$ServerName is Offline!"
    Write-Output ("-" * $LineSize)
    Write-Output "Error: Unable to connect to $ServerName!"
    Write-Output "Either the $ServerName is down or check for firewall settings on server $ServerName!"
}


if ($SError -ne $null -and $SError) {
    Write-Output "`nScript was unable to query following servers:"
    Write-Output ("-" * $LineSize)
    $SError
}

if ($SDown -ne $null -and $SDown) {
    Write-Output "`nScript was unable to connect to the following server:"
    Write-Output ("-" * $LineSize)
    $SDown
}

if ($queryResults -ne $null -and $queryResults) {

    Write-Output "`n`nList of disconnected session:"
    Write-Output ("-" * $LineSize)
    $QueryResultsCSV = $queryResults | ConvertFrom-Csv -Delimiter "," -Header "ServerName","UserName","SessionID","CurrentState","IdealTime","LogonTime"
    $QueryResultsCSV |ft -AutoSize

    Write-Output "`nStarting logoff procedure..."
    Write-Output ("-" * $LineSize)
    $QueryResultsCSV | foreach {
        $Sessionl = $_.SessionID
        $Serverl = $_.ServerName
        $username = $_.username
        Write-Output "Logging off $username from $serverl..."
        
        logoff $Sessionl /server:$Serverl /v

    }
}
else {
    Write-Output ("`n`n`n`n" + "*" * $LineSize )
    Write-Output "You are all good! No disconnected sessions found!"
    Write-Output ("*" * $LineSize)
    if ($AqueryResults -ne $null -and $AqueryResults) {
        Write-Output "`n`nList of active session:"
        Write-Output ("-" * $LineSize)

        Write-Output "Warning: There are some active sessions found"
        Write-Output "Script does not logoff active sessions, you can ask LT for this feature"
    
    
        $AqueryResultsCSV = $AqueryResults | ConvertFrom-Csv -Delimiter "," -Header "ServerName","UserName","SessionName","SessionID","CurrentState","IdealTime","LogonTime"
        $AqueryResultsCSV |ft -AutoSize
    }
    

}