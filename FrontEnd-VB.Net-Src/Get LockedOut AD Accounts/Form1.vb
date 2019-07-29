Imports System
Imports System.IO
Imports System.Text
Imports System.Linq
Imports System.Environment
Imports System.Configuration
Imports System.Deployment.Application
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces


Public Class GetLockedOutADForm

    Dim CurrWidth As Integer = Me.Width
    Dim index As Integer

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer.Stop()
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker1.MaxDate = DateTime.Now
        SharePath.Text = My.Settings.USharePath
        lblVersion.Text = String.Format("Version: 1.4.0.34")

    End Sub


    Private Sub Search_Click_1(sender As Object, e As EventArgs) Handles Search.Click

        CheckBox1.Text = "Search all records for this username"
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        SharePath.Text = SharePath.Text.TrimEnd("\\") + "\"
        My.Settings.USharePath = SharePath.Text

        'set minimum form width
        Me.Width = CurrWidth
        DateTimePicker1.MaxDate = DateTime.Now

        CurrentFile.BackColor = Color.DodgerBlue
        CurrentFile.ForeColor = Color.Silver


        Dim FormWidth As Integer = Me.Width
        Dim Width As Integer
        Dim intWidth As Integer = 0
        Dim addwidth As Integer = 0
        Dim rowNumber As Integer = 1
        index = 0

        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

        DataGridView1.DataSource = Nothing

        EnterUsername.Font = New Font(EnterUsername.Font, FontStyle.Bold)
        EnterUsername.TextAlign = HorizontalAlignment.Center

        Dim Username As String = EnterUsername.Text.Trim
        Dim thisDay As String = DateTimePicker1.Value.ToString("MM-dd-yy")
        Dim ResultFound As Boolean = False
        Dim Path As String = SharePath.Text
        Dim FileName As String = "Security-Events_" & thisDay & ".csv"
        Dim FilePath As String = Path & FileName

        If Directory.Exists(Path) Then

            ChangeAndPersistSettings()

            SharePath.BackColor = Color.DarkGreen
            SharePath.ForeColor = Color.White

            If CheckBox1.Checked Then
                Dim Dir As New System.IO.DirectoryInfo(Path)
                Dim FileList = Dir.GetFiles("Security-Events_*.*", System.IO.SearchOption.AllDirectories)

                Dim QueryMatchingFiles = From file In FileList
                                         Where file.Extension = ".csv"
                                         Let fileText = GetFileText(file.FullName)
                                         Where fileText.ToLower.Contains(Username.ToLower())
                                         Select file.Name

                If FileList Is Nothing Then
                    MsgBox("No files found, please check access to network or path: " & Path, MsgBoxStyle.Critical)
                    CurrentFile.Text = "No files found, please check access to network or path: " & Path
                    CurrentFile.BackColor = Color.Red
                    CurrentFile.ForeColor = Color.White
                    CurrentFile.Font = New Font(CurrentFile.Font, FontStyle.Bold)
                Else
                    For Each FileName In QueryMatchingFiles
                        GetRecords(FileName, Path, Username)
                    Next
                    If DataGridView1.RowCount = 0 Then
                        MsgBox("No locked out events found for " & Username & ". Please try another username." & vbCrLf & "*Note: If this is a recent lockout, then please wait 5 minutes and try again at """ & Date.Now.AddMinutes(5).ToString("hh:mm tt") & """", MsgBoxStyle.Information)
                        CurrentFile.Text = "No locked for: " & Username
                        CurrentFile.BackColor = Color.Red
                        CurrentFile.ForeColor = Color.White
                        CurrentFile.Font = New Font(CurrentFile.Font, FontStyle.Bold)
                        BlinkControl()

                    End If

                End If
            Else
                If File.Exists(FilePath) Then
                    If File.ReadAllLines(FilePath).Length <> 0 Then
                        GetRecords(FileName, Path, Username)
                    End If
                ElseIf Not File.Exists(FilePath) Then
                    MsgBox("File not found: " & FileName & ". Please try another date.", MsgBoxStyle.Critical)
                    CurrentFile.Text = "File not found: " & FileName
                    CurrentFile.BackColor = Color.Red
                    CurrentFile.ForeColor = Color.White
                    CurrentFile.Font = New Font(CurrentFile.Font, FontStyle.Bold)
                ElseIf File.ReadAllLines(FilePath).Length = 0 Then

                    MsgBox("No locked out events found in: " & FileName & ". Please try another date.", MsgBoxStyle.Information)
                    CurrentFile.Text = "File is empty: " & FileName
                    CurrentFile.BackColor = Color.Red
                    CurrentFile.ForeColor = Color.White
                    CurrentFile.Font = New Font(CurrentFile.Font, FontStyle.Bold)
                End If
            End If


            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.IsNewRow Then Continue For
                row.HeaderCell.Value = "" & rowNumber
                rowNumber = rowNumber + 1
            Next

            DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)



            For Each c In DataGridView1.Controls
                If c.GetType() Is GetType(VScrollBar) Then
                    Dim vbar As VScrollBar = DirectCast(c, VScrollBar)
                    If vbar.Visible = True Then
                        'Do whatever you like
                        'addwidth = 25
                        addwidth = vbar.Width

                    End If
                End If
            Next


            intWidth = DataGridView1.RowHeadersWidth

            For Each dgvcc As DataGridViewColumn In DataGridView1.Columns
                intWidth += dgvcc.Width
            Next

            'If intWidth > "425" Then
            If (intWidth + addwidth) > DataGridView1.Width Then

                Width = intWidth - DataGridView1.Width + addwidth
                Me.Width = Me.Width + Width + 2

            End If
        Else
            MsgBox("Path not found, please check access to network or path: " & Path & ".", MsgBoxStyle.Critical)
            'SharePath.Text = "Path not found, please check access to network or path: " & SharePath.Text & "."
            SharePath.BackColor = Color.Red
            SharePath.ForeColor = Color.White

            'SharePath.Font = New Font(SharePath.Font, FontStyle.Bold)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Enterusername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EnterUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search.PerformClick()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            DataGridView1.Rows(e.RowIndex).Selected = True
            index = e.RowIndex
            DataGridView1.CurrentCell = DataGridView1.Rows(e.RowIndex).Cells(1)
            ContextMenuStrip1.Show(DataGridView1, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)

        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Click
        If Not DataGridView1.Rows(index).IsNewRow Then
            Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Dim username As String = DataGridView1.Rows(index).Cells(1).Value.ToString
            Dim hostname As String = DataGridView1.Rows(index).Cells(2).Value.ToString
            Dim scriptOut As String

            MsgBox("Logging off """ & username & """" & " from host """ & hostname & """")
            scriptOut = RunScript(LoadScript(SharePath.Text & "GLU-LT-LogOff.ps1", username, hostname))
            MsgBox(scriptOut)

            Cursor = Cursors.Default
        End If
    End Sub
#Enable Warning BC42105 ' Function doesn't return a value on all code paths

    Private Sub BlinkControl()
        For index As Integer = 1 To 5
            Console.WriteLine("Chaning color to white")
            CheckBox1.ForeColor = Color.White
            Console.WriteLine("waiting")
            'System.Threading.Thread.Sleep(10)
            Console.WriteLine("Chaning color to red")
            CheckBox1.ForeColor = Color.Red
        Next
        CheckBox1.ForeColor = Color.Red
    End Sub


    Function GetFileText(ByVal name As String) As String

        ' If the file has been deleted, the right thing  
        ' to do in this case is return an empty string.  
        Dim fileContents = String.Empty

        ' If the file has been deleted since we took   
        ' the snapshot, ignore it and return the empty string.  
        If System.IO.File.Exists(name) Then
            fileContents = System.IO.File.ReadAllText(name)
        End If

        Return fileContents

    End Function

    Function GetRecords(ByVal GRFilename As String, ByVal GRPath As String, ByVal GRUsername As String)

        Dim ResultFound As Boolean = False
        Dim GRFilePath As String = GRPath & GRFilename

        'MsgBox("Checking file: " & GRFilename)

        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "Time"
        DataGridView1.Columns(1).Name = "Username"
        DataGridView1.Columns(2).Name = "Hostname"
        'MsgBox("Looking for username: " & Username & ". Please wait...", MsgBoxStyle.Information)

        CurrentFile.Text = GRFilename
        CurrentFile.ForeColor = Color.White
        CurrentFile.Font = New Font(CurrentFile.Font, FontStyle.Bold)

        Dim FileLength = File.ReadAllLines(GRFilePath).Length
        'MsgBox(FileLength)
        Dim Counter As Integer = 0

        ProgressBar1.Visible = True
        'ProgressBar1.Value = 1
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = FileLength
        ProgressBar1.Step = 1

        Using MyReader As New FileIO.TextFieldParser(GRFilePath)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData

                Try
                    currentRow = MyReader.ReadFields()
                    Dim NewRow(3) As Object

                    Dim TimeTextTemp As String = currentRow(0)
                    Dim UsernameText As String = currentRow(1).Trim
                    Dim HostnameText As String = currentRow(2)

                    If HostnameText.ToLower <> "clientname" Then
                        'Dim TimeText As DateTime = Date.ParseExact(currentRow(0), "yyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        Dim TimeText As DateTime = Convert.ToDateTime(TimeTextTemp)
                        NewRow(0) = TimeText
                        NewRow(1) = UsernameText
                        NewRow(2) = HostnameText

                        If UsernameText.ToLower Like ("*" & GRUsername.ToLower & "*") Then
                            'DataGridView1.Rows(Counter).HeaderCell.Value = "" & Counter
                            'DataGridView1.Rows.Add(currentRow)
                            DataGridView1.Rows.Add(NewRow)
                            Counter += 1
                            ResultFound = True
                        ElseIf GRUsername = String.Empty Then
                            DataGridView1.Rows.Add(currentRow)
                            ResultFound = True
                        End If

                        ProgressBar1.PerformStep()
                    End If
                Catch ex As Microsoft.VisualBasic.
                          FileIO.MalformedLineException
                    'Error code here
                End Try
            End While



            If ResultFound = False And CheckBox1.Checked = False Then

                MsgBox("No locked out events found for: " & GRUsername & vbCrLf & "*Note 1: If this is a recent lockout, then please wait 5 minutes. and try again at """ & Date.Now.AddMinutes(5).ToString("hh:mm tt") & """" & vbCrLf & "**Note 2: You can also try the option ""Search all records for: " & GRUsername & """", MsgBoxStyle.Information)
                CheckBox1.Text = "Search all records for: " & GRUsername
                Timer.Start()
            End If

        End Using


#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function


    ' Takes script text as input and runs it, then converts 
    ' the results to a string to return to the user 

    Private Function RunScript(ByVal scriptText As String) As String

        ' create Powershell runspace 
        Dim MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()


        ' open it 
        MyRunSpace.Open()

        ' create a pipeline and feed it the script text 
        Dim MyPipeline As Pipeline = MyRunSpace.CreatePipeline()

        'Dim getProcessCStarted As New Command(scriptText)
        'Dim testparam = (scriptText & username)
        'MsgBox(testparam)
        'MsgBox(scriptText)
        'MyPipeline.Commands.AddScript(testparam)
        'MsgBox("$Username =  """ & username & """")
        'MyPipeline.Commands.Add("$Username =  """ & username & """")
        MyPipeline.Commands.AddScript(scriptText)

        'getProcessCStarted.Parameters.Add(Username, Hostname)

        ' add an extra command to transform the script output objects into nicely formatted strings 
        ' remove this line to get the actual objects that the script returns. For example, the script 
        ' "Get-Process" returns a collection of System.Diagnostics.Process instances. 
        'MyPipeline.Commands.Add(getProcessCStarted)

        MyPipeline.Commands.Add("Out-String")


        ' execute the script 
        Dim results As Collection(Of PSObject) = MyPipeline.Invoke()

        ' close the runspace 
        MyRunSpace.Close()

        ' convert the script result into a single string 
        Dim MyStringBuilder As New StringBuilder()

        For Each obj As PSObject In results
            MyStringBuilder.AppendLine(obj.ToString())
        Next

        ' return the results of the script that has 
        ' now been converted to text 
        Return MyStringBuilder.ToString()

    End Function

    ' helper method that takes your script path, loads up the script 
    ' into a variable, and passes the variable to the RunScript method 
    ' that will then execute the contents 
    Private Function LoadScript(ByVal filename As String, ByVal username As String, ByVal hostname As String) As String

        Try

            ' Create an instance of StreamReader to read from our file. 
            ' The using statement also closes the StreamReader. 
            Dim sr As New StreamReader(filename)

            ' use a string builder to get all our lines from the file 
            Dim fileContents As New StringBuilder()

            ' string to hold the current line 
            Dim curLine As String = ""
            curLine = ("$Username =  """ & username & """" + vbCrLf)
            curLine += ("$Servername =  """ & hostname & """" + vbCrLf)
            fileContents.Append(curLine + vbCrLf)

            ' loop through our file and read each line into our 
            ' stringbuilder as we go along 
            Do
                ' read each line and MAKE SURE YOU ADD BACK THE 
                ' LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF 
                curLine = sr.ReadLine()
                fileContents.Append(curLine + vbCrLf)
            Loop Until curLine Is Nothing

            ' close our reader now that we are done 
            sr.Close()

            ' call RunScript and pass in our file contents 
            ' converted to a string 
            Return fileContents.ToString()

        Catch e As Exception
            ' Let the user know what went wrong. 
            Dim errorText As String = "The file could not be read:"
            errorText += e.Message + "\n"
            Return errorText
        End Try

    End Function

    Private Sub ChangeAndPersistSettings()
        My.Settings.LastChange = Today
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        index = index + 1
        Console.WriteLine(index)
        If CLng(index) Mod 2 > 0 Then
            Console.WriteLine("Chaning color to white")
            CheckBox1.ForeColor = Color.White
        Else
            Console.WriteLine("Chaning color to red")
            CheckBox1.ForeColor = Color.Red
        End If

        If index = 8 Then
            CheckBox1.ForeColor = Color.DarkGreen
            Console.WriteLine("Stopping timer")
            Console.WriteLine("Chaning color to red")
            Timer.Stop()
        End If
    End Sub
    Private Sub SharePath_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Search.PerformClick()
        End If
    End Sub
End Class




