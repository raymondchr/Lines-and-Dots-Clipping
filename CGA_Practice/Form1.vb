Imports System.Drawing.Pen

Public Class Form1

    Dim IsItInside As Boolean
    Dim btndrline As Boolean
    Dim btndrdot As Boolean
    Dim btndrclip As Boolean
    Dim delDot As Boolean 'delete outside window
    Dim delInside As Boolean
    Dim trivialacc As Boolean
    Dim clearclip As Boolean
    Dim hasclipped As Boolean 'unused
    Dim mc As Integer = 0
    Dim X1, X2, Y1, Y2 As Integer
    Dim windowX, windowY, windowH, windowW As Integer
    Dim pen1 As New Pen(Color.Black, 2)
    Dim pen2 As New Pen(Color.Red, 2)
    Dim penclip1 As New Pen(Color.Red, 2)
    Dim eraser As New Pen(Color.White, 2)
    Dim DotList As LinkedList(Of Point) = New LinkedList(Of Point)
    Dim LineList As LinkedList(Of Point) = New LinkedList(Of Point)
    Dim LOut As LinkedList(Of Point) = New LinkedList(Of Point)
    Dim bmp As Bitmap

    Structure TPoint
        Dim x, y As Double
    End Structure
    Structure TLine
        Dim p1, p2 As Integer
    End Structure
    Dim clippos(1) As TPoint
    Sub SetPoint(ByRef P As TPoint, ByVal x As Double, ByVal y As Double) 'unused
        P.x = x
        P.y = y
    End Sub
    Sub SetLine(ByRef L As TLine, ByVal n1 As Integer, ByVal n2 As Integer) 'unused
        L.p1 = n1
        L.p2 = n2
    End Sub
    'function to draw points
    Sub point()
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim i As Integer

        While i <= DotList.Count - 1
            gr.DrawRectangle(pen1, DotList(i).X, DotList(i).Y, 1, 1)
            i += 1
        End While
    End Sub
    'function to draw lines
    Sub garis()
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim i As Integer

        While i <= LineList.Count
            gr.DrawLine(pen1, LineList(i).X, LineList(i).Y, LineList(i + 1).X, LineList(i + 1).Y)
            i += 2
        End While

    End Sub
    'function to draw clipping window
    Sub clipwin()
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim i As Integer = 0
        Dim tempx, tempy, tempx1, tempy1 As Integer

        tempx = clippos(0).x
        tempy = clippos(0).y
        tempx1 = clippos(1).x - clippos(0).x
        tempy1 = clippos(1).y - clippos(0).y

        While i <= 1
            gr.DrawRectangle(pen2, tempx, tempy, tempx1, tempy1)
            i = 2
        End While
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp

        btn_cleardotoutside.Enabled = False
        btn_deleteinside.Enabled = False
        btn_clip.Enabled = False
    End Sub
    Private Sub Btn_Clear_MouseClick(sender As Object, e As MouseEventArgs) Handles btn_Clear.MouseClick
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub
    'to get coordinates of point(s)
    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        mc = mc + 1
        'drawing dot function
        If btndrdot Then
            X1 = e.X
            Y1 = e.Y
            DotList.AddLast(New Point(X1, Y1))
            DotListBox.Items.Add(CStr(X1) + ", " + CStr(Y1))
            point()
            mc = 0
            PictureBox1.Refresh()
        End If
        'drawing line function
        If btndrline Then
            If mc = 1 Then
                X1 = e.X
                Y1 = e.Y
            ElseIf mc = 2 Then
                X2 = e.X
                Y2 = e.Y
                mc = 0
                LineList.AddLast(New Point(X1, Y1))
                LineList.AddLast(New Point(X2, Y2))
                LineListBox.Items.Add(CStr(X1) + ", " + CStr(Y1) + ", " + CStr(X2) + ", " + CStr(Y2))
                garis()
                PictureBox1.Refresh()
            End If
        End If
        'drawing clip
        If btndrclip Then
            If mc = 1 Then
                X1 = e.X
                Y1 = e.Y
            ElseIf mc = 2 Then
                X2 = e.X
                Y2 = e.Y

                If X1 > X2 Then
                    windowX = X2
                    windowW = X1 - X2
                Else
                    windowX = X1
                    windowW = X2 - X1
                End If

                If Y1 > Y2 Then
                    windowY = Y2
                    windowH = Y1 - Y2
                Else
                    windowY = Y1
                    windowH = Y2 - Y1
                End If
                clippos(0).x = windowX
                clippos(0).y = windowY
                clippos(1).x = windowX + windowW
                clippos(1).y = windowY + windowH
                bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                PictureBox1.Image = bmp
                garis()
                point()
                clipwin()
                mc = 0
                PictureBox1.Refresh()
            End If
        End If
    End Sub
    'function to clip point
    Sub clipdot()
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim i, x1, y1, j As Integer
        Dim top, bot, right, left As Integer

        top = windowY
        bot = windowY + windowH
        right = windowX + windowW
        left = windowX

        i = DotList.Count

        While j <= i
            x1 = DotList(j).X
            y1 = DotList(j).Y
            IsPointInWindow(x1, y1, top, bot, right, left)

            If IsItInside Then
                gr.DrawRectangle(penclip1, x1, y1, 1, 1)
                If delInside Then
                    gr.DrawRectangle(eraser, x1, y1, 1, 1)
                End If
            ElseIf delDot Then
                gr.DrawRectangle(eraser, x1, y1, 1, 1)
            End If
            j += 1
        End While
    End Sub
    'function to clip line
    Sub clipline()
        Dim gr As Graphics = Graphics.FromImage(bmp)
        Dim i, j, x1, y1, x2, y2 As Integer
        Dim tempx, tempy, tempx1, tempy1 As Integer

        i = LineList.Count

        While j <= i - 1
            x1 = LineList(j).X
            y1 = LineList(j).Y
            x2 = LineList(j + 1).X
            y2 = LineList(j + 1).Y

            Cohen_Sutherland(x1, y1, x2, y2)

            tempx = LOut(j).X
            tempy = LOut(j).Y
            tempx1 = LOut(j + 1).X
            tempy1 = LOut(j + 1).Y

            If trivialacc Then
                If delDot Then
                    gr.DrawLine(eraser, x1, y1, x2, y2)
                    gr.DrawLine(penclip1, tempx, tempy, tempx1, tempy1)
                    gr.DrawRectangle(penclip1, tempx, tempy, 1, 1)
                    gr.DrawRectangle(penclip1, tempx1, tempy1, 1, 1)
                Else
                    If clearclip Then
                        gr.DrawLine(eraser, tempx, tempy, tempx1, tempy1) 'unfinished implementation
                    Else
                        gr.DrawLine(eraser, tempx, tempy, tempx1, tempy1) 'unfinished implementation
                    End If
                End If
            End If
            j = j + 2
        End While
    End Sub
    'button to clear the list of objects bitmap
    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
        clearclip = False
        DotList.Clear()
        LineList.Clear()
        LOut.Clear()
        LineListBox.Items.Clear()
        DotListBox.Items.Clear()
    End Sub
    'to clip object(s) inside the clipping window
    Private Sub Btn_clip_Click(sender As Object, e As EventArgs) Handles btn_clip.Click
        Dim gr As Graphics = Graphics.FromImage(bmp)
        PictureBox1.Image = bmp

        hasclipped = True

        If btndrclip Then
            clipdot()
            clipline()
        End If
    End Sub
    'clip outside clipping window button
    Private Sub Btn_cleardotoutside_Click(sender As Object, e As EventArgs) Handles btn_cleardotoutside.Click
        Dim gr As Graphics = Graphics.FromImage(bmp)
        delDot = True
        delInside = False
        clearclip = False
        btn_clip.Enabled = True
    End Sub
    'clip inside clipping window button
    Private Sub Btn_deleteinside_Click(sender As Object, e As EventArgs) Handles btn_deleteinside.Click
        btn_clip.Enabled = True
        delDot = False
        delInside = True
        clearclip = False
    End Sub
    'to delete single point in the listbox
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_deldot.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
        Dim coords As String
        Dim strArr() As String
        coords = DotListBox.SelectedItem
        strArr = coords.Split(", ")
        Dim dot As Point = New Point(CInt(strArr(0)), CInt(strArr(1)))
        If DotList.Contains(dot) Then
            DotListBox.Items.Remove(DotListBox.SelectedItem)
            DotList.Remove(dot)
        End If
        garis() 'added after submission
        point()
        clipwin()
        PictureBox1.Refresh()
    End Sub
    'to delete a single line from the listbox
    Private Sub Btn_delline_Click(sender As Object, e As EventArgs) Handles btn_delline.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
        Dim coords As String
        Dim strArr() As String
        coords = LineListBox.SelectedItem
        strArr = coords.Split(", ")
        Dim dot1 As Point = New Point(CInt(strArr(0)), CInt(strArr(1)))
        Dim dot2 As Point = New Point(CInt(strArr(2)), CInt(strArr(3)))
        If LineList.Contains(dot1) And LineList.Contains(dot2) Then
            LineListBox.Items.Remove(LineListBox.SelectedItem)
            LineList.Remove(dot1)
            LineList.Remove(dot2)
        End If
        garis()
        point() 'added after submission
        clipwin()
        PictureBox1.Refresh()
    End Sub
    'clearing the clipping window
    Private Sub Btn_clearclip_Click(sender As Object, e As EventArgs) Handles btn_clearclip.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp

        clearclip = True
        If hasclipped Then
            garis()
            point()
            clipdot()
            clipline()
            hasclipped = False 'added this line after submission
        Else
            garis()
            point()
        End If
    End Sub
    'to show pointer coordinates
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        lbl_X.Text = Convert.ToString(e.X)
        lbl_Y.Text = Convert.ToString(e.Y)
    End Sub
    'mode selector start
    Private Sub Btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        mc = 0
        If ComboBox1.Text = "Dot" Then
            btndrline = False
            btndrdot = True
            btndrclip = False
            lbl_mode.Text = "Dot"
        End If
        If ComboBox1.Text = "Line" Then
            btndrline = True
            btndrdot = False
            btndrclip = False
            lbl_mode.Text = "Line"
        End If
        If ComboBox1.Text = "Clipping Window" Then
            btndrline = False
            btndrdot = False
            btndrclip = True
            btn_cleardotoutside.Enabled = True
            btn_deleteinside.Enabled = True
            btn_clip.Enabled = False
            lbl_mode.Text = "Clip"
        End If
    End Sub
    'Area_code
    Function Area_Code(X As Integer, y As Integer, top As Integer, bot As Integer, right As Integer, left As Integer)
        Dim N As Integer = 0

        If y < top Then
            N = N + 8
        ElseIf y > bot Then
            N = N + 4
        End If

        If X > right Then
            N = N + 2
        ElseIf X < left Then
            N = N + 1
        End If
        Return N
    End Function
    'cohen-sutherland algo
    Public Sub Cohen_Sutherland(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Dim C1, C2 As Integer
        Dim andop As Integer
        Dim orop As Integer
        Dim Cout As Integer
        Dim dx, dy As Integer
        Dim finalX, finalY As Integer
        Dim ysatu, xsatu, ydua, xdua As Integer
        ysatu = y1
        xsatu = x1
        xdua = x2
        ydua = y2

        dx = x2 - x1
        dy = y2 - y1

        C1 = Area_Code(xsatu, ysatu, windowY, (windowY + windowH), (windowX + windowW), windowX)
        C2 = Area_Code(xdua, ydua, windowY, (windowY + windowH), (windowX + windowW), windowX)

        andop = (C1 And C2)
        orop = (C1 Or C2)

        While True
            andop = (C1 And C2)
            orop = (C1 Or C2)
            ysatu = y1
            xsatu = x1
            xdua = x2
            ydua = y2
            If andop <> 0 Then
                trivialacc = False
                Exit While
            ElseIf orop = 0 Then
                trivialacc = True
                LOut.AddLast(New Point(xsatu, ysatu))
                LOut.AddLast(New Point(xdua, ydua))
                Exit While
            Else
                If C1 > 0 Then
                    Cout = C1
                Else
                    Cout = C2
                End If

                If (Cout And 8) <> 0 Then
                    finalX = xsatu + dx * (windowY - ysatu) / dy
                    finalY = windowY
                ElseIf (Cout And 4) <> 0 Then
                    finalX = xsatu + dx * ((windowY + windowH) - ysatu) / dy
                    finalY = windowY + windowH
                ElseIf (Cout And 2) <> 0 Then
                    finalY = ysatu + dy * ((windowX + windowW) - xsatu) / dx
                    finalX = (windowX + windowW)
                Else
                    finalY = ysatu + dy * (windowX - xsatu) / dx
                    finalX = windowX
                End If

                If Cout = C1 Then
                    x1 = finalX
                    y1 = finalY
                    C1 = Area_Code(x1, y1, windowY, (windowY + windowH), (windowX + windowW), windowX)
                Else
                    x2 = finalX
                    y2 = finalY
                    C2 = Area_Code(x2, y2, windowY, (windowY + windowH), (windowX + windowW), windowX)
                End If
            End If
        End While
    End Sub
    'function to check whether the point is inside the clipping window
    Function IsPointInWindow(x1 As Integer, y1 As Integer, top As Integer, bottom As Integer, right As Integer, left As Integer)
        Dim pixelpoint As Integer
        Dim area1 As Integer
        Dim area2 As Integer

        If left <= x1 And x1 <= right Then
            area1 = 0
        Else
            area1 = 1
        End If

        If y1 <= bottom And y1 >= top Then
            area2 = 0
        Else
            area2 = 1
        End If

        pixelpoint = area1 Or area2

        If pixelpoint = 0 Then
            IsItInside = True
        Else
            IsItInside = False
        End If

        Return IsItInside
    End Function
End Class