Imports System.Text.RegularExpressions
Imports System.IO
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Using x As New Net.WebClient
            Dim getSource As String = x.DownloadString("https://www.socks-proxy.net")
            Dim proxyRegex As String = "\<tr\>\<td\>(.*?)\<\/td\>\<td\>(.*?)\<\/td\>\<td\>(.*?)<\/td\>"

            For Each match As Match In Regex.Matches(getSource, proxyRegex)

                Dim itm As New ListViewItem
                itm.Text = match.Groups(1).Value
                itm.SubItems.Add(match.Groups(2).Value)
                itm.SubItems.Add(match.Groups(3).Value)
                ListView1.Items.Add(itm)

            Next

        End Using
        Using x As New Net.WebClient
            Dim getSource As String = x.DownloadString("https://free-proxy-list.net")
            Dim proxyRegex As String = "\<tr\>\<td\>(.*?)\<\/td\>\<td\>(.*?)\<\/td\>\<td\>(.*?)\<\/td\>"

            For Each match As Match In Regex.Matches(getSource, proxyRegex)

                Dim itm As New ListViewItem
                itm.Text = match.Groups(1).Value
                itm.SubItems.Add(match.Groups(2).Value)
                itm.SubItems.Add(match.Groups(3).Value)
                ListView1.Items.Add(itm)

            Next

        End Using
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim save As New SaveFileDialog
        save.Filter = "Text files (*.txt)|*.txt"

        If save.ShowDialog = DialogResult.OK Then

            Dim sw As New StreamWriter(save.FileName)
            For Each itm As ListViewItem In ListView1.Items
                sw.WriteLine(itm.Text & ":" & itm.SubItems(1).Text)
            Next
            sw.Close()

        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Process.Start("https://www.facebook.com/groups/e.internet/")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Process.Start("https://www.youtube.com/channel/UCCZX5sZL964uXhruKKNZjkw")
    End Sub
End Class
