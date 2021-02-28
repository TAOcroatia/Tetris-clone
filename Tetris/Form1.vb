Imports System.Threading

Public Class Form1
    Dim pb(10, 20) As PictureBox
    Dim rnd As New Random
    Dim ls As String = 11111111
    Dim oa As Integer = 1
    Dim ob As Integer = 1
    Dim ocol As Color
    Dim ap As Integer = 0
    Dim bp As Integer = 0
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Dim lsm As Integer
    'rotation position
    Dim rota As Integer = 2
    Public Event UnhandledException As UnhandledExceptionEventHandler
    Dim yon As Integer = 0
    Dim cnt As Integer
    Dim r As Integer
    Dim chk As Integer = 0
    Dim active As Array
    Dim florex As String = "abc"
    Dim break As Boolean = False
    Dim lines As New List(Of String)
    Dim datalines As New List(Of String)

    'blocks
    Dim i(4) As Integer
    Dim j(4) As Integer
    Dim l(4) As Integer
    Dim o(4) As Integer
    Dim s(4) As Integer
    Dim t(4) As Integer
    Dim z(4) As Integer

    'colors
    Dim ic As Color = Color.Cyan
    Dim jc As Color = Color.Blue
    Dim lc As Color = Color.Orange
    Dim oc As Color = Color.Yellow
    Dim sc As Color = Color.Green
    Dim tc As Color = Color.Purple
    Dim zc As Color = Color.Red

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        startspawn()
        Timer1.Start()
    End Sub
    Private Sub startspawn()
        'randomly spawn blocks at top
        Timer1.Stop()

        Dim c As Integer = rnd.Next(1, 8)
        If c = 1 Then
            spawner3000(i(1), ic, 0, 0)
            lsm = 1
        ElseIf c = 2 Then
            spawner3000(j(1), jc, 0, 0)
            lsm = 2
        ElseIf c = 3 Then
            spawner3000(l(1), lc, 0, 0)
            lsm = 3
        ElseIf c = 4 Then
            spawner3000(o(1), oc, 0, 0)
            lsm = 4
        ElseIf c = 5 Then
            spawner3000(s(1), sc, 0, 0)
            lsm = 5
        ElseIf c = 6 Then
            spawner3000(t(1), tc, 0, 0)
            lsm = 6
        ElseIf c = 7 Then
            spawner3000(z(1), zc, 0, 0)
            lsm = 7
        End If
    End Sub
    Private Sub spawner3000(blk As String, col As Color, a As Integer, b As Integer)
        Dim c As Integer = 0
        Dim chr As Char
        Dim x As Integer
        Dim y As Integer
        Dim conv As String
        Dim lookl As Boolean
        Dim lookr As Boolean
        break = False
        Timer1.Start()

        If break = True Then
            chr = ""
            x = 0
            y = 0
            c = 0
            conv = ""
        End If
        If break = True Then
            ap = 0
            bp = 0
            rota = 2
            lsm = 0
            ls = 11111111
            oa = 1
            ob = 1
            ap = 0
            bp = 0
            lsm = 0
            rota = 2
            yon = 0
            cnt = 0
            r = 0
            chk = 0
            florex = "abc"
            startspawn()
        End If

        While c <= 7
            chr = ls(c)
            conv = Convert.ToString(chr)
            x = Convert.ToInt32(conv)
            c = c + 1
            chr = ls(c)
            conv = Convert.ToString(chr)
            y = Convert.ToInt32(conv)
            c = c + 1
            pb(x + oa, y + ob).BackColor = Color.SlateGray
        End While

        If checkaround(blk, a, b)(0) < 1 Then
            a = a + 1
            ap = ap + 1
        End If
        If checkaround(blk, a, b)(1) > 10 Then
            a = a - 1
            ap = ap - 1
        End If

        If checkaround(blk, a, b)(2) = 1 Then
            a = a + 1
            ap = ap + 1
        End If
        If checkaround(blk, a, b)(2) = 2 Then
            a = a - 1
            ap = ap - 1
        End If

        'If lookl = True AndAlso checkaround(blk, a, b)(2) = 1 Then
        '    a = a + 1
        '    ap = ap + 1
        'ElseIf lookl = False AndAlso checkaround(blk, a, b)(2) = 1 Then
        '    lookl = True
        'ElseIf checkaround(blk, a, b)(2) = 3 Then
        '    lookl = False
        'End If
        'If lookr = True AndAlso checkaround(blk, a, b)(2) = 2 Then
        '    a = a - 1
        '    ap = ap - 1
        'ElseIf lookr = False AndAlso checkaround(blk, a, b)(2) = 2 Then
        '    lookr = True
        'ElseIf checkaround(blk, a, b)(2) = 3 Then
        '    lookr = False
        'End If

        If checkaround(blk, a, b)(0) > 0 And checkaround(blk, a, b)(1) < 11 And checkaround(blk, a, b)(2) = 3 Then

            If r = 1 Then
                x = 0
                y = 0
                r = 0
            End If
            Checkunder(blk, a, b)
            fullline()

            c = 0
            While c <= 7
                chr = blk(c)
                conv = Convert.ToString(chr)
                x = Convert.ToInt32(conv)
                c = c + 1
                chr = blk(c)
                conv = Convert.ToString(chr)
                y = Convert.ToInt32(conv)
                c = c + 1
                pb(x + a, y + b).BackColor = col
            End While
            oa = a
            ob = b
            ls = blk
            ocol = col
        End If
    End Sub
    Private Sub Checkunder(blk As String, a As Integer, b As Integer)
        Dim offseta As Integer = 8
        Dim offsetb As Integer = 0
        Dim blktmp As String = ""
        Dim chkblk As String = ""
        Dim blklist(200) As String
        For i As Integer = 1 To 7
            If blk.Substring(i, 1) > offsetb Then
                offsetb = blk.Substring(i, 1)
            End If
            i = i + 1
        Next

        For i As Integer = 0 To 6
            If blk.Substring(i, 1) < offseta Then
                offseta = blk.Substring(i, 1)
            End If
            i = i + 1
        Next

        If b + offsetb = 20 Then
            'checks if it is on bottom
            break = True
        End If
        For i As Integer = 0 To blk.Length - 1 Step 2
            blklist(i) = blk.Substring(i, 2)
        Next

        For i As Integer = 0 To blk.Length - 1 Step 2
            blktmp = blk.Substring(i, 2) + 1
            If Not blklist.Contains(blktmp) = True Then
                blktmp = blktmp - 1
                chkblk = chkblk & blktmp
            End If
        Next

        For i As Integer = 0 To chkblk.Length - 1 Step 2
            Dim tmp1 As Integer = chkblk.Substring(i, 1)
            Dim tmp2 As Integer = chkblk.Substring(i + 1, 1)
            If break = False Then
                If tmp1 + b + 1 >= 20 Then
                    If pb(tmp1 + a, tmp2 + b + 1).BackColor <> Color.SlateGray Then
                        break = True
                    End If
                ElseIf tmp1 + b + 1 > 20 Then
                    If pb(tmp1 + a, tmp2 + b).BackColor <> Color.SlateGray Then
                        break = True
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub fullline()
        Dim empty As Integer = True
        lines.Add("0")

        For y As Integer = 1 To 20
            Dim c As Integer = 0
            For x As Integer = 1 To 10
                If Not pb(x, y).BackColor = Color.SlateGray Then
                    c = c + 1
                End If
                If c = 10 AndAlso lines.IndexOf(y) = -1 Then
                    lines.Add(y)
                End If
            Next
        Next
        datalines = lines

        If lines.Count > 0 Then
            For i As Integer = 1 To lines.Count - 1
                Dim cnt As Integer = 0
                For ii As Integer = lines(i) To 2 Step -1
                    For iii As Integer = 1 To 10
                        pb(iii, lines(i) - cnt).BackColor = pb(iii, lines(i) - cnt - 1).BackColor
                    Next
                    cnt = cnt + 1
                Next
            Next
            lines.Clear()
        End If
        lines.Remove("0")
    End Sub
    Private Function checkaround(blk As String, a As Integer, b As Integer)
        Dim lines As New List(Of String)
        Dim left As Integer = 10
        Dim right As Integer = 0
        Dim blklist As New List(Of String)
        Dim blktmp As String
        Dim chkblkl As String
        Dim chkblkr As String
        Dim pba(10, 20) As Boolean

        For y As Integer = 1 To 20
            For x As Integer = 1 To 10
                pba(x, y) = New Boolean
                Console.WriteLine(pb(x, y).BackColor)
                If pb(x, y).BackColor <> Color.SlateGray Then
                    Console.WriteLine("true")
                    pba(x, y) = True
                End If
                If pba(x, y) = True Then
                    Console.Write("o")
                ElseIf pba(x, y) = False Then
                    Console.Write("c")
                End If
            Next
            Console.WriteLine()
        Next


        For i As Integer = 0 To blk.Length - 1 Step 2
            lines.Add(blk.Substring(i, 2))
        Next
        For i As Integer = 0 To lines.Count - 1
            If lines(i).Substring(0, 1) < left Then left = lines(i).Substring(0, 1)
            If lines(i).Substring(0, 1) > right Then right = lines(i).Substring(0, 1)
        Next

        For i As Integer = 0 To blk.Length - 1 Step 2
            blklist.Add(blk.Substring(i, 2))
        Next

        For i As Integer = 0 To blk.Length - 1 Step 2
            blktmp = blk.Substring(i, 2)
            blktmp = blktmp.Substring(0, 1) - 1 & blktmp.Substring(1, 1)
            If blklist.Contains(blktmp) = False Then
                blktmp = blktmp - 1
                chkblkl = chkblkl & blk.Substring(i, 2)
            End If
        Next

        For i As Integer = 0 To blk.Length - 1 Step 2
            blktmp = blk.Substring(i, 2)
            blktmp = blktmp.Substring(0, 1) + 1 & blktmp.Substring(1, 1)
            If blklist.Contains(blktmp) = False Then
                blktmp = blktmp - 1
                chkblkr = chkblkr & blk.Substring(i, 2)
            End If
        Next
        datalines = lines
        lines.Clear()
        lines.Add(left + a)
        lines.Add(right + a)

        blklist.Clear()
        For i As Integer = 0 To chkblkr.Length - 1 Step 2
            blklist.Add(chkblkr.Substring(i, 2))
        Next

        For i As Integer = 0 To blklist.Count - 1
            Console.WriteLine(right + a & " " & a + blklist(i).Substring(0, 1) & " " & b + blklist(i).Substring(1, 1))
            If right + a < 10 AndAlso pba(a + blklist(i).Substring(0, 1), b + blklist(i).Substring(1, 1)) = True Then
                'Console.WriteLine("right")
                If Not lines.Contains(2) Then
                    lines.Add(2)
                End If
            End If
        Next

        blklist.Clear()
        For i As Integer = 0 To chkblkr.Length - 1 Step 2
            blklist.Add(chkblkl.Substring(i, 2))
        Next

        For i As Integer = 0 To blklist.Count - 1
            Console.WriteLine(left + a & " " & a + blklist(i).Substring(0, 1) & " " & b + blklist(i).Substring(1, 1))
            If left + a > 1 AndAlso pba(a + blklist(i).Substring(0, 1), b + blklist(i).Substring(1, 1)) = True Then
                'Console.WriteLine("left")
                If Not lines.Contains(1) Then
                    lines.Add(1)
                End If
            End If
        Next
        If lines.Count = 2 Then lines.Add("3")
        Return lines
    End Function
    Public Sub data()
        i(1) = (41516171)
        i(2) = (61626364)
        i(3) = (42526272)
        i(4) = (51525354)

        j(1) = (41425262)
        j(2) = (51615253)
        j(3) = (42526263)
        j(4) = (51524353)

        l(1) = (61425262)
        l(2) = (51525363)
        l(3) = (42526243)
        l(4) = (41515253)

        o(1) = (51615262)
        o(2) = (51615262)
        o(3) = (51615262)
        o(4) = (51615262)

        s(1) = (51614252)
        s(2) = (51526263)
        s(3) = (52624353)
        s(4) = (41425253)

        t(1) = (51425262)
        t(2) = (51526253)
        t(3) = (42526253)
        t(4) = (51425253)

        z(1) = (41515262)
        z(2) = (61526253)
        z(3) = (42525363)
        z(4) = (51425243)
    End Sub
    Private Sub Form1_Load() Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim a As Integer = 1
        Dim b As Integer = 1
        While b <= 20
            pb(a, b) = New PictureBox
            Panel1.Controls.Add(pb(a, b))
            'active(a, b) = New Boolean
            pb(a, b).Location = New Point(x, y)
            pb(a, b).Width = 30
            pb(a, b).Height = 30
            pb(a, b).BackColor = Color.SlateGray
            If x = 270 Then
                x = 0
                y = y + 30
            Else
                x = x + 30
            End If
            If a = 10 Then
                a = 1
                b = b + 1
            Else
                a = a + 1
            End If
        End While
        Dataform.Show()
        'spawnwalls()
        data()
        Timer2.Start()
    End Sub
    Private Sub spawnwalls()
        'Ode san sta
        Dim a As Integer = 0
        Dim b As Integer = 0
        While b <= 20
            pb(a, b) = New PictureBox
            Panel1.Controls.Add(pb(a, b))
            pb(a, b).BackColor = Color.Black
            pb(a, b).Location = New Point(a * 31, b * 31)
            If a = 10 Then
                a = 0
                b = b + 1
            Else
                a = a + 10
            End If
        End While
        While b <= 20
            pb(a, b) = New PictureBox
            Panel1.Controls.Add(pb(a, b))
            pb(a, b).BackColor = Color.Black
            pb(a, b).Location = New Point(a * 31, b * 31)
            If a = 10 Then
                a = 0
                b = b + 20
            Else
                a = a + 1
            End If
        End While
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        pb(1, 1).BackColor = Color.SlateGray
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If break = True Then
            ap = 0
            bp = 0
            rota = 2
            lsm = 0
            ls = 11111111
            oa = 1
            ob = 1
            ap = 0
            bp = 0
            lsm = 0
            rota = 2
            yon = 0
            cnt = 0
            r = 0
            chk = 0
            florex = "abc"
            startspawn()
        End If
        If GetAsyncKeyState(37) Then
            ap = ap - 1
            spawner3000(ls, ocol, ap, bp)
        ElseIf GetAsyncKeyState(39) Then
            ap = ap + 1
            spawner3000(ls, ocol, ap, bp)
        ElseIf GetAsyncKeyState(40) Then
            bp = bp + 1
            spawner3000(ls, ocol, ap, bp)
        ElseIf GetAsyncKeyState(38) Then
            If rota = 5 Then
                rota = 1
            End If

            If lsm = 1 Then
                    spawner3000(i(rota), ic, oa, ob)
                    lsm = 1
                ElseIf lsm = 2 Then
                    spawner3000(j(rota), jc, oa, ob)
                    lsm = 2
                ElseIf lsm = 3 Then
                    spawner3000(l(rota), lc, oa, ob)
                    lsm = 3
                ElseIf lsm = 4 Then
                    spawner3000(o(rota), oc, oa, ob)
                    lsm = 4
                ElseIf lsm = 5 Then
                    spawner3000(s(rota), sc, oa, ob)
                    lsm = 5
                ElseIf lsm = 6 Then
                    spawner3000(t(rota), tc, oa, ob)
                    lsm = 6
                ElseIf lsm = 7 Then
                    spawner3000(z(rota), zc, oa, ob)
                    lsm = 7
                End If

            rota = rota + 1
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        bp = bp + 1
        spawner3000(ls, ocol, ap, bp)
    End Sub
    Dim cntt As Integer
    Dim rott As Integer
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dataform.DataGridView1.ColumnHeadersHeight = 20
        For i As Integer = 1 To 20
            If Not Dataform.DataGridView1.Rows.Count < 9 Then
                Dataform.DataGridView1.Rows.RemoveAt(i)
            End If
            For ii As Integer = 1 To 10
                Console.WriteLine(lines.Count)
                Console.WriteLine(i & " " & ii)
                Dataform.DataGridView1.Rows.Add(datalines(i).Substring(ii))
            Next
        Next

        'If cntt = 1 Then
        '    spawner3000(i(rott), ic, 1, 1)
        '    lsm = 1
        'ElseIf cntt = 2 Then
        '    spawner3000(j(rott), jc, 1, 1)
        '    lsm = 2
        'ElseIf cntt = 3 Then
        '    spawner3000(l(rott), lc, 1, 1)
        '    lsm = 3
        'ElseIf cntt = 4 Then
        '    spawner3000(o(rott), oc, 1, 1)
        '    lsm = 4
        'ElseIf cntt = 5 Then
        '    spawner3000(s(rott), sc, 1, 1)
        '    lsm = 5
        'ElseIf cntt = 6 Then
        '    spawner3000(t(rott), tc, 1, 1)
        '    lsm = 6
        'ElseIf cntt = 7 Then
        '    spawner3000(z(rott), zc, 1, 1)
        '    lsm = 7
        'End If


        'If cntt >= 8 Then
        '    cntt = 1
        'End If
        'If rott = 4 Then
        '    rott = 0
        '    cntt = cntt + 1
        'End If
        'rott = rott + 1
    End Sub
    ' <>
End Class
