Imports _01_HolaMundo_WindowsFormsC

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Instancia de la clase persona en vb
        Dim oPersona As New clsPersona
        oPersona.nombre = "Rafa"
        oPersona.apellidos = "Mateos"
        MessageBox.Show("Soy el objeto" + oPersona.nombre + oPersona.apellidos)


    End Sub
End Class
