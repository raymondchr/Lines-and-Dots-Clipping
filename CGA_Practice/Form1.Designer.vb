<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_select = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_X = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Y = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_mode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btn_clip = New System.Windows.Forms.Button()
        Me.btn_clearclip = New System.Windows.Forms.Button()
        Me.LineListBox = New System.Windows.Forms.ListBox()
        Me.DotListBox = New System.Windows.Forms.ListBox()
        Me.btn_cleardotoutside = New System.Windows.Forms.Button()
        Me.btn_deleteinside = New System.Windows.Forms.Button()
        Me.btn_delline = New System.Windows.Forms.Button()
        Me.btn_deldot = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(433, 402)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Dot", "Line", "Clipping Window"})
        Me.ComboBox1.Location = New System.Drawing.Point(556, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(172, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(467, 84)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(83, 24)
        Me.btn_Clear.TabIndex = 7
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_select
        '
        Me.btn_select.Location = New System.Drawing.Point(467, 39)
        Me.btn_select.Name = "btn_select"
        Me.btn_select.Size = New System.Drawing.Size(83, 24)
        Me.btn_select.TabIndex = 16
        Me.btn_select.Text = "Select"
        Me.btn_select.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbl_X, Me.ToolStripStatusLabel3, Me.lbl_Y, Me.ToolStripStatusLabel5, Me.lbl_mode})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(751, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(23, 17)
        Me.ToolStripStatusLabel1.Text = "X : "
        '
        'lbl_X
        '
        Me.lbl_X.Name = "lbl_X"
        Me.lbl_X.Size = New System.Drawing.Size(12, 17)
        Me.lbl_X.Text = "-"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(29, 17)
        Me.ToolStripStatusLabel3.Text = "| Y : "
        '
        'lbl_Y
        '
        Me.lbl_Y.Name = "lbl_Y"
        Me.lbl_Y.Size = New System.Drawing.Size(12, 17)
        Me.lbl_Y.Text = "-"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(94, 17)
        Me.ToolStripStatusLabel5.Text = "| Selected Mode:"
        '
        'lbl_mode
        '
        Me.lbl_mode.Name = "lbl_mode"
        Me.lbl_mode.Size = New System.Drawing.Size(74, 17)
        Me.lbl_mode.Text = "Not Selected"
        '
        'btn_clip
        '
        Me.btn_clip.Location = New System.Drawing.Point(556, 84)
        Me.btn_clip.Name = "btn_clip"
        Me.btn_clip.Size = New System.Drawing.Size(83, 24)
        Me.btn_clip.TabIndex = 20
        Me.btn_clip.Text = "Clip"
        Me.btn_clip.UseVisualStyleBackColor = True
        '
        'btn_clearclip
        '
        Me.btn_clearclip.Location = New System.Drawing.Point(645, 84)
        Me.btn_clearclip.Name = "btn_clearclip"
        Me.btn_clearclip.Size = New System.Drawing.Size(83, 24)
        Me.btn_clearclip.TabIndex = 21
        Me.btn_clearclip.Text = "ClearClip"
        Me.btn_clearclip.UseVisualStyleBackColor = True
        '
        'LineListBox
        '
        Me.LineListBox.FormattingEnabled = True
        Me.LineListBox.Location = New System.Drawing.Point(467, 169)
        Me.LineListBox.Name = "LineListBox"
        Me.LineListBox.Size = New System.Drawing.Size(129, 108)
        Me.LineListBox.TabIndex = 19
        '
        'DotListBox
        '
        Me.DotListBox.FormattingEnabled = True
        Me.DotListBox.Location = New System.Drawing.Point(611, 169)
        Me.DotListBox.Name = "DotListBox"
        Me.DotListBox.Size = New System.Drawing.Size(129, 108)
        Me.DotListBox.TabIndex = 22
        '
        'btn_cleardotoutside
        '
        Me.btn_cleardotoutside.Location = New System.Drawing.Point(467, 127)
        Me.btn_cleardotoutside.Name = "btn_cleardotoutside"
        Me.btn_cleardotoutside.Size = New System.Drawing.Size(83, 24)
        Me.btn_cleardotoutside.TabIndex = 28
        Me.btn_cleardotoutside.Text = "Clear Outside"
        Me.btn_cleardotoutside.UseVisualStyleBackColor = True
        '
        'btn_deleteinside
        '
        Me.btn_deleteinside.Location = New System.Drawing.Point(556, 127)
        Me.btn_deleteinside.Name = "btn_deleteinside"
        Me.btn_deleteinside.Size = New System.Drawing.Size(83, 24)
        Me.btn_deleteinside.TabIndex = 29
        Me.btn_deleteinside.Text = "Clear Inside"
        Me.btn_deleteinside.UseVisualStyleBackColor = True
        '
        'btn_delline
        '
        Me.btn_delline.Location = New System.Drawing.Point(467, 302)
        Me.btn_delline.Name = "btn_delline"
        Me.btn_delline.Size = New System.Drawing.Size(83, 24)
        Me.btn_delline.TabIndex = 30
        Me.btn_delline.Text = "Delete Line"
        Me.btn_delline.UseVisualStyleBackColor = True
        '
        'btn_deldot
        '
        Me.btn_deldot.Location = New System.Drawing.Point(611, 302)
        Me.btn_deldot.Name = "btn_deldot"
        Me.btn_deldot.Size = New System.Drawing.Size(83, 24)
        Me.btn_deldot.TabIndex = 31
        Me.btn_deldot.Text = "Delete Point"
        Me.btn_deldot.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 453)
        Me.Controls.Add(Me.btn_deldot)
        Me.Controls.Add(Me.btn_delline)
        Me.Controls.Add(Me.btn_deleteinside)
        Me.Controls.Add(Me.btn_cleardotoutside)
        Me.Controls.Add(Me.DotListBox)
        Me.Controls.Add(Me.btn_clearclip)
        Me.Controls.Add(Me.btn_clip)
        Me.Controls.Add(Me.LineListBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btn_select)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btn_Clear As Button
    Friend WithEvents btn_select As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Private WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lbl_X As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents lbl_Y As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents lbl_mode As ToolStripStatusLabel
    Friend WithEvents btn_clip As Button
    Friend WithEvents btn_clearclip As Button
    Friend WithEvents LineListBox As ListBox
    Friend WithEvents DotListBox As ListBox
    Friend WithEvents btn_cleardotoutside As Button
    Friend WithEvents btn_deleteinside As Button
    Friend WithEvents btn_delline As Button
    Friend WithEvents btn_deldot As Button
End Class
