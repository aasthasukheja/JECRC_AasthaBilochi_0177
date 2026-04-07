import React, { useMemo } from "react";
import { useEmployees } from "../context/EmployeeContext";

function Analytics() {
  const { employees } = useEmployees();

  const analytics = useMemo(() => {
    const totalEmployees = employees.length;
    const activeEmployees = employees.filter((emp) => emp.status === "Active").length;
    const inactiveEmployees = employees.filter((emp) => emp.status === "Inactive").length;
    const totalSalary = employees.reduce((sum, emp) => sum + emp.salary, 0);
    const averageSalary = totalEmployees > 0 ? Math.round(totalSalary / totalEmployees) : 0;

    return {
      totalEmployees,
      activeEmployees,
      inactiveEmployees,
      totalSalary,
      averageSalary,
    };
  }, [employees]);

  return (
    <div className="analytics-grid">
      <div className="card stat-card">
        <h3>Total Employees</h3>
        <p>{analytics.totalEmployees}</p>
      </div>

      <div className="card stat-card">
        <h3>Active Employees</h3>
        <p>{analytics.activeEmployees}</p>
      </div>

      <div className="card stat-card">
        <h3>Inactive Employees</h3>
        <p>{analytics.inactiveEmployees}</p>
      </div>

      <div className="card stat-card">
        <h3>Total Salary</h3>
        <p>₹{analytics.totalSalary}</p>
      </div>

      <div className="card stat-card">
        <h3>Average Salary</h3>
        <p>₹{analytics.averageSalary}</p>
      </div>
    </div>
  );
}

export default Analytics;