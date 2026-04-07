import React from "react";
import { useEmployees } from "../context/EmployeeContext";

function EmployeeList({ setEditingEmployee }) {
  const { employees, deleteEmployee } = useEmployees();

  return (
    <div className="card">
      <h2>Employee Records</h2>

      {employees.length === 0 ? (
        <p>No employees found.</p>
      ) : (
        <table className="employee-table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Department</th>
              <th>Role</th>
              <th>Salary</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>

          <tbody>
            {employees.map((emp) => (
              <tr key={emp.id}>
                <td>{emp.name}</td>
                <td>{emp.department}</td>
                <td>{emp.role}</td>
                <td>₹{emp.salary}</td>
                <td>{emp.status}</td>
                <td>
                  <button
                    className="btn small-btn secondary-btn"
                    onClick={() => setEditingEmployee(emp)}
                  >
                    Edit
                  </button>
                  <button
                    className="btn small-btn danger-btn"
                    onClick={() => deleteEmployee(emp.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default EmployeeList;