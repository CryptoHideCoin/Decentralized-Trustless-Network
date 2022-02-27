Option Compare Text
Option Explicit On

' ****************************************
' File: Numberic Text
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports System.Threading
Imports System.Globalization






Public Class NumericText

    Inherits TextBox


    Private _CurrentFormat As String = ""
    Private _DecimalChar As String = ""
    Private _LocationCode As String
    Private _DecimalPeriod As Boolean = False
    Private _NumberFormat As NumberFormatInfo
    Private _Buffer As String = ""

    Private Property decimalChar() As String
        Get
            If useDecimal Then
                Return _DecimalChar
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            _DecimalChar = value
        End Set
    End Property


    ''' <summary>
    ''' This method provide to initialize the component
    ''' </summary>
    <DebuggerHiddenAttribute()> Public Sub New()
        locationCode = Thread.CurrentThread.CurrentCulture.Name
        _NumberFormat = New CultureInfo(_LocationCode, False).NumberFormat
    End Sub

    ''' <summary>
    ''' This property get/let if in the control wish a decimal value
    ''' </summary>
    ''' <returns></returns>
    Public Property useDecimal() As Boolean = False
    ''' <summary>
    ''' This property get/let the location code (to configure format)
    ''' </summary>
    ''' <returns></returns>
    Public Property locationCode() As String
        Get
            Return _LocationCode
        End Get
        Set(value As String)
            Try
                _NumberFormat = New CultureInfo(value, False).NumberFormat

                _LocationCode = value
                _DecimalChar = _NumberFormat.NumberDecimalSeparator
            Catch ex As Exception
            End Try
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the current format of a field
    ''' </summary>
    ''' <returns></returns>
    Public Property currentFormat() As String
        Get
            Return _CurrentFormat
        End Get
        Set(value As String)
            _CurrentFormat = value
        End Set
    End Property
    ''' <summary>
    ''' This property get/let the text value
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Property text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            Try
                MyBase.Text = Decimal.Parse(value, NumberStyles.Currency, _NumberFormat).ToString(_CurrentFormat, _NumberFormat)
                'MyBase.Text = value
            Catch ex As Exception
                MyBase.Text = "0"
            End Try
        End Set
    End Property
    ''' <summary>
    ''' This property get the value in the decimal type
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Value As Decimal
        Get
            If MyBase.Text.Length = 0 Then
                MyBase.Text = "0"
            End If
            Return Decimal.Parse(MyBase.Text, Globalization.NumberStyles.Currency, _NumberFormat)
        End Get
    End Property


    Private Sub DecimalTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        If MyBase.Text.Length = 0 Then
            MyBase.Text = "0"
        End If
        MyBase.Text = Decimal.Parse(MyBase.Text, Globalization.NumberStyles.Currency, _NumberFormat).ToString
    End Sub

    Private Sub DecimalTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus
        If MyBase.Text.Length = 0 Then
            MyBase.Text = "0"
        End If
        MyBase.Text = Decimal.Parse(MyBase.Text, Globalization.NumberStyles.Currency, _NumberFormat).ToString(_CurrentFormat, _NumberFormat)
        _DecimalPeriod = False
    End Sub

    Private Sub DecimalTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        _Buffer = MyBase.Text
        If e.KeyChar = Chr(8) Then
            If MyBase.Text.Length = 0 Then Exit Sub
            If MyBase.Text.Chars(MyBase.Text.Length - 1) = decimalChar Then
                _DecimalPeriod = False
            End If
            Exit Sub
        ElseIf Char.IsNumber(e.KeyChar) = False Then
            If e.KeyChar = decimalChar Then
                If MyBase.Text.Length = 0 And MyBase.SelectionLength = 0 Then
                    e.Handled = True
                    Exit Sub
                End If
                If _DecimalPeriod = False And MyBase.SelectionLength = 0 Then
                    _DecimalPeriod = True
                    Exit Sub
                Else
                    e.Handled = True
                End If
            End If
            e.Handled = True
            Exit Sub
        End If
        If IsNumber(Text) = False Then
            MyBase.Text = _Buffer
        End If
    End Sub

    Private Function IsNumber(ByVal str As String) As Boolean
        Dim counter As Integer
        Dim validator As Boolean
        For counter = 0 To str.Length - 1
            If Char.IsDigit(str.Chars(counter)) = False Then
                If str.Chars(counter) = decimalChar And validator = False Then
                    validator = True
                Else
                    Return False
                    Exit Function
                End If
            End If
        Next

        Return True
    End Function

    Private Sub DecimalTextBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        MyBase.SelectAll()
    End Sub

    Private Sub DecimalTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If MyBase.Enabled = False Or MyBase.ReadOnly = True Then
            MyBase.Text = Decimal.Parse(MyBase.Text, Globalization.NumberStyles.Currency, _NumberFormat).ToString(_CurrentFormat, _NumberFormat)
        End If
    End Sub

    Private Sub NumericText_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = 46) Then
            _DecimalPeriod = False
        End If
    End Sub

End Class
