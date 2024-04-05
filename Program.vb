Imports System

Public Class Employee
    Public Property ID As Integer
    Public Property Name As String
    Public Property Department As String

    ' Constructor 
    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal department As String)
        Me.ID = id
        Me.Name = name
        Me.Department = department
    End Sub

    ' Destructor 
    Protected Overrides Sub Finalize()
        Console.WriteLine($"Employee '{Name}' has been removed from the system.")
        MyBase.Finalize()
    End Sub
End Class

Public Class EmployeeManagementSystem
    Private employees As List(Of Employee)

    Public Sub New()
        employees = New List(Of Employee)()
    End Sub

    ' Function to add an employee
    Public Sub AddEmployee(ByVal employee As Employee)
        employees.Add(employee)
        Console.WriteLine($"Employee '{employee.Name}' added successfully.")
    End Sub

    ' Function to remove an employee by ID
    Public Sub RemoveEmployee(ByVal employeeId As Integer)
        Dim employeeToRemove = employees.Find(Function(emp) emp.ID = employeeId)

        If employeeToRemove IsNot Nothing Then
            employees.Remove(employeeToRemove)
            ' Note: We're not explicitly calling destructor (Finalize) here as it's not recommended practice.
            Console.WriteLine($"Employee with ID {employeeId} removed successfully.")
        Else
            Console.WriteLine($"Employee with ID {employeeId} not found.")
        End If
    End Sub

    ' Function to display all employees
    Public Sub DisplayEmployees()
        If employees.Count > 0 Then
            Console.WriteLine("Employee List:")
            For Each emp In employees
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}")
            Next
        Else
            Console.WriteLine("No employees found.")
        End If
    End Sub
End Class

Module Program
    Sub Main(args As String())
        Dim empSystem As New EmployeeManagementSystem()

        Dim choice As Integer
        Do
            Console.WriteLine()
            Console.WriteLine("Employee Management System")
            Console.WriteLine("1. Add Employee")
            Console.WriteLine("2. Remove Employee")
            Console.WriteLine("3. Display Employees")
            Console.WriteLine("4. Exit")
            Console.Write("Enter your choice: ")
            Integer.TryParse(Console.ReadLine(), choice)

            Select Case choice
                Case 1

                    Console.Write("Enter Employee ID: ")
                    Dim id As Integer = Integer.Parse(Console.ReadLine())
                    Console.Write("Enter Employee Name: ")
                    Dim name As String = Console.ReadLine()
                    Console.Write("Enter Employee Department: ")
                    Dim department As String = Console.ReadLine()


                    Dim newEmployee As New Employee(id, name, department)
                    empSystem.AddEmployee(newEmployee)

                Case 2

                    Console.Write("Enter Employee ID to remove: ")
                    Dim idToRemove As Integer = Integer.Parse(Console.ReadLine())
                    empSystem.RemoveEmployee(idToRemove)

                Case 3

                    empSystem.DisplayEmployees()

                Case 4

                    Console.WriteLine("Exiting...")
                    Exit Do

                Case Else
                    Console.WriteLine("Invalid choice. Please enter a valid option.")
            End Select
        Loop While True

        Console.ReadLine()
    End Sub
End Module
