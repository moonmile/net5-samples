Imports Microsoft.EntityFrameworkCore

Public Class blazordbContext
    Inherits DbContext

    Public Sub New()

    End Sub

    Public Sub New(options As DbContextOptions(Of blazordbContext))
        MyBase.New(options)
    End Sub

    Public Overridable Property Books As DbSet(Of Book)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        If Not optionsBuilder.IsConfigured Then
            optionsBuilder.UseSqlServer("Server=.;Database=blazordb;Trusted_connection=True")
        End If
    End Sub

End Class
