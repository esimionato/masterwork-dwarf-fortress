﻿Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class comboFileItem
    Inherits comboItem

    Private m_fileName As String

    <CategoryAttribute("Data"),
    DisplayNameAttribute("File Name"),
    DescriptionAttribute("The file this item represents.")> _
    Public Property fileName As String
        Get
            Return m_fileName
        End Get
        Set(value As String)
            m_fileName = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return MyBase.ToString() & " " & m_fileName
    End Function

End Class

Public Class comboFileItemCollection
    Inherits CollectionBase

    Public ReadOnly Property Item(index As Integer) As comboFileItem
        Get
            Return DirectCast(List(index), comboFileItem)
        End Get
    End Property

    Public Sub Add(ByVal t As comboFileItem)
        List.Add(t)
    End Sub

    Public Sub Remove(ByVal t As comboFileItem)
        List.Remove(t)
    End Sub

    Public Sub Replace(ByVal t As comboFileItem, ByVal index As Integer)
        If List.Count > 0 And index < List.Count - 1 Then
            List.RemoveAt(index)
            List.Insert(index, t)
        End If
    End Sub
End Class

Public Class comboFileItemCollectionEditor
    Inherits CollectionEditor

    Public Sub New()
        MyBase.New(GetType(comboFileItemCollection))
    End Sub
End Class

