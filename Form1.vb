Imports System.Diagnostics.Eventing.Reader

Public Class Form1
    'Displaring constant
    Dim dblOffSeason As Double = 50
    Dim dblPeakSeason As Double = 150
    Dim dblStandardSeason As Double = 100

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Closing program
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear inputs and outputs
        txtFirstName.ResetText()
        txtLastName.ResetText()
        txtEmail.ResetText()
        txtPhoneNumber.ResetText()
        txtDays.ResetText()

        txtFirstName.Focus()
        radStandard.Checked = True

        radOffSeason.Checked = False
        radPeakSeason.Checked = False

        lblSubtotal.Text = ""
        lblTax.Text = ""
        lblTotal.Text = ""

    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        Dim intDays As Integer
        Dim dblSeasonCost As Double
        Dim dblTotalDiscount As Double

        Dim dblSubtotal As Double
        Dim dblTax As Double
        Dim dblTotal As Double

        'Validate Input
        If txtPhoneNumber.Text = "" Then
            MessageBox.Show("Phone number must be entered")
            txtPhoneNumber.Focus()
        End If

        If txtEmail.Text = "" Then
            MessageBox.Show("Email address must be entered")
            txtEmail.Focus()
        End If

        If IsNumeric(txtDays.Text) Then
            intDays = txtDays.Text
            If intDays < 1 Then
                MessageBox.Show("Number of days must greater than 0")
                txtDays.Focus()
            End If
        Else
            MessageBox.Show("Number of days must be numeric")
            txtDays.Focus()
        End If

        'calculation
        If radOffSeason.Checked Then
            dblSeasonCost = intDays * dblOffSeason
        End If

        If radPeakSeason.Checked Then
            dblSeasonCost = intDays * dblPeakSeason
        End If

        If radStandard.Checked Then
            dblSeasonCost = intDays * dblStandardSeason
        End If

        If intDays > 30 Then
            dblTotalDiscount = (dblSeasonCost * 10) / 100
            ' dblTotal = dblSubtotal * .1
        Else
            If intDays > 14 Then
                dblTotalDiscount = (dblSeasonCost * 5) / 100
                ' dblTotal = dblSubtotal * .05
            End If
        End If

        dblSubtotal = dblSeasonCost - dblTotalDiscount
        dblTax = dblSubtotal * 0.1
        dblTotal = dblSubtotal + dblTax


        'display output
        lblSubtotal.Text = FormatCurrency(dblSubtotal)
        lblTax.Text = FormatCurrency(dblTax)
        lblTotal.Text = FormatCurrency(dblTotal)

    End Sub
End Class
