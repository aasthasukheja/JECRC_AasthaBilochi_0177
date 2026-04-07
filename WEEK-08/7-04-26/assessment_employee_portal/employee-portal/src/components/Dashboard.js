import React, { useState } from "react";
import EmployeeForm from "./EmployeeForm";
import EmployeeList from "./EmployeeList";
import Analytics from "./Analytics";
import Settings from "./Settings";

function Dashboard() {
  const [activeTab, setActiveTab] = useState("employees");
  const [editingEmployee, setEditingEmployee] = useState(null);

  return (
    <div>
      <div className="tabs">
        <button
          className={activeTab === "employees" ? "tab active-tab" : "tab"}
          onClick={() => setActiveTab("employees")}
        >
          Employees
        </button>
        <button
          className={activeTab === "analytics" ? "tab active-tab" : "tab"}
          onClick={() => setActiveTab("analytics")}
        >
          Analytics
        </button>
        <button
          className={activeTab === "settings" ? "tab active-tab" : "tab"}
          onClick={() => setActiveTab("settings")}
        >
          Settings
        </button>
      </div>

      {activeTab === "employees" && (
        <div className="dashboard-grid">
          <EmployeeForm
            editingEmployee={editingEmployee}
            setEditingEmployee={setEditingEmployee}
          />
          <EmployeeList setEditingEmployee={setEditingEmployee} />
        </div>
      )}

      {activeTab === "analytics" && <Analytics />}
      {activeTab === "settings" && <Settings />}
    </div>
  );
}

export default Dashboard;