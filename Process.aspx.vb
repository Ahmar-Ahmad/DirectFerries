
Partial Class Process
    Inherits System.Web.UI.Page
    Protected Sub Page_Load()
        Dim fullname As String = Request.QueryString("fullname")
        Dim dob As String = Request.QueryString("dob")
        'welcome message
        Dim firstname As String = fullname.Substring(0, fullname.IndexOf(" "))
        Response.Write("Welcome " & firstname & "<br />")
        'vowel count
        Dim vcount As Integer = 0
        Dim vowels As String = "aeiou"

        For Each c As Char In firstname.ToLower
            If vowels.Contains(c) Then
                vcount += 1
            End If
        Next

        If vcount = 1 Then
            Response.Write("You have " & vcount.ToString() & " vowel in your name.<br />")
        Else
            Response.Write("You have " & vcount.ToString() & " vowels in your name.<br />")
        End If

        'calculate current age and days before birthday

        Dim birthdate As DateTime = CDate(dob)
        Dim currentdate As DateTime = DateTime.Now
        Dim age As Integer = currentdate.Year - birthdate.Year
        If currentdate.Month < birthdate.Month OrElse (currentdate.Month = birthdate.Month AndAlso currentdate.Day < birthdate.Day) Then
            age -= 1
        End If

        Dim nextbirthday As DateTime = New DateTime(currentdate.Year, birthdate.Month, birthdate.Day)
        If nextbirthday < currentdate Then
            nextbirthday = nextbirthday.AddYears(1)
        End If
        Dim daysuntilbirthday As Integer = (nextbirthday - currentdate).Days
        Response.Write("You are " & age & " years old. <br />")
        Response.Write("Your next birthday is in " & daysuntilbirthday & " days.<br />")

        'write table of 14 days before
        Dim daysbeforebirthday As String = ""
        Dim actualdate As DateTime
        Dim actualday As String = ""
        Dim actualmonth As String = ""
        Dim dayofweek As String = ""
        Dim rowstring As String = ""
        Dim hrefstring As String = ""
        Dim actualdatestr As String = ""
        'define table & header
        rowstring = "<table id=" & Chr(34) & "table1" & Chr(34) & " style=" & Chr(34) & "border-width:1; border-color:Black" & Chr(34) & "runat=" & Chr(34) & "server" & Chr(34) & ">"
        Response.Write(rowstring)
        rowstring = "<tr><th>Days Before Birthday</th><th>Day Of Week</th><th>Date Link</th></tr>"
        Response.Write(rowstring)
        For x = 14 To 0 Step -1
            'create a row for table
            'days before birthday / day of week (mon, tue, wed, etc), date with link
            daysbeforebirthday = x.ToString()
            actualdate = currentdate.AddDays(daysuntilbirthday + 1 - x)
            actualdatestr = actualdate.ToShortDateString()
            dayofweek = actualdate.DayOfWeek.ToString()
            actualmonth = actualdate.Month.ToString()
            actualmonth = DateAndTime.MonthName(actualmonth)
            actualday = actualdate.Day.ToString()
            If actualday.Length = 1 Then
                'append a 0 to the day 
                actualday = "0" & actualday
            End If
            hrefstring = "https://www.historynet.com/today-in-history/" & actualmonth & "-" & actualday
            'create row in table for current values
            rowstring = "<tr><td>" & daysbeforebirthday & "</td><td>" & dayofweek & "</td><td><a href=" & Chr(34) & hrefstring & Chr(34) & " target=" & Chr(34) & "_blank" & Chr(34) & ">" & actualdatestr & "</a></td></tr>"
            Response.Write(rowstring)
        Next
        'close table
        rowstring = "</table>"
        Response.Write(rowstring)

    End Sub
End Class
