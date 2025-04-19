'Copyright 2025 八宝粥(Email:1749861851@qq.com)

'Licensed under the Apache License, Version 2.0 (the "License");
'you may Not use this file except In compliance With the License.
'You may obtain a copy Of the License at

'    http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law Or agreed To In writing, software
'distributed under the License Is distributed On an "AS IS" BASIS,
'WITHOUT WARRANTIES Or CONDITIONS Of ANY KIND, either express Or implied.
'See the License For the specific language governing permissions And
'limitations under the License.
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Module 管理员身份运行检测
    ' 导入 Windows API 函数
    <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function IsUserAnAdmin() As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Public Function 是否以管理员身份运行() As Boolean
        Try
            ' 方法 1：通过 .NET 内置角色检查
            Dim principal As New WindowsPrincipal(WindowsIdentity.GetCurrent())
            Dim isAdminByRole As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
            ' 方法 2：通过 Windows API 检查（兼容旧系统）
            Dim isAdminByAPI As Boolean = IsUserAnAdmin()
            ' 综合判断（双重验证）
            Return isAdminByRole AndAlso isAdminByAPI
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
