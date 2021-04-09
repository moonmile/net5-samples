Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        Dim content As New blazordbContext

        Dim query = From t In content.Books
                    Where t.Id = 3
                    Select t
        Dim item = query.FirstOrDefault()

        System.Diagnostics.Debug.WriteLine(item.Title)
    End Sub
End Class
