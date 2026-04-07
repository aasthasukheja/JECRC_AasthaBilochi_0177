import React, { useEffect, useState } from "react";
import { useEmployees } from "../context/EmployeeContext";

function EmployeeForm({ editingEmployee, setEditingEmployee }) {
  const { addEmployee, updateEmployee } = useEmployees();

  const [formData, setFormData] = useState({
    name: "",
    department: "",
    role: "",
    salary: "",
    status: "Active",
  });

  useEffect(() => {
    if (editingEmployee) {
      setFormData(editingEmployee);
    } else {
      setFormData({
        name: "",
        department: "",
        role: "",
        salary: "",
        status: "Active",
      });
    }
  }, [editingEmployee]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!formData.name || !formData.department || !formData.role || !formData.salary) {
      alert("Please fill all fields.");
      return;
    }

    const employeeData = {
      ...formData,
      salary: Number(formData.salary),
    };

    if (editingEmployee) {
      updateEmployee(employeeData);
      setEditingEmployee(null);
    } else {
      addEmployee(employeeData);
    }

    setFormData({
      name: "",
      department: "",
      role: "",
      salary: "",
      status: "Active",
    });
  };

  const handleCancelEdit = () => {
    setEditingEmployee(null);
    setFormData({
      name: "",
      department: "",
      role: "",
      salary: "",
      status: "Active",
    });
  };

  return (
    <div className="card">
      <h2>{editingEmployee ? "Edit Employee" : "Add Employee"}</h2>

      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Name</label>
          <input name="name" value={formData.name} onChange={handleChange} />
        </div>

        <div className="form-group">
          <label>Department</label>
          <input name="department" value={formData.department} onChange={handleChange} />
        </div>

        <div className="form-group">
          <label>Role</label>
          <input name="role" value={formData.role} onChange={handleChange} />
        </div>

        <div className="form-group">
          <label>Salary</label>
          <input
            name="salary"
            type="number"
            value={formData.salary}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>Status</label>
          <select name="status" value={formData.status} onChange={handleChange}>
            <option value="Active">Active</option>
            <option value="Inactive">Inactive</option>
          </select>
        </div>

        <div className="button-row">
          <button type="submit" className="btn primary-btn">
            {editingEmployee ? "Update Employee" : "Add Employee"}
          </button>

          {editingEmployee && (
            <button
              type="button"
              className="btn secondary-btn"
              onClick={handleCancelEdit}
            >
              Cancel
            </button>
          )}
        </div>
      </form>
    </div>
  );
}

export default EmployeeForm;