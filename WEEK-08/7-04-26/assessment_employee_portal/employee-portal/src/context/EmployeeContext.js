import React, { createContext, useContext, useMemo, useReducer, useCallback } from "react";

const EmployeeContext = createContext();

const initialState = {
  employees: [
    { id: 1, name: "Aastha", department: "AI & DS", role: "Developer", salary: 50000, status: "Active" },
    { id: 2, name: "Rohit", department: "HR", role: "HR Executive", salary: 42000, status: "Active" },
    { id: 3, name: "Sneha", department: "Finance", role: "Analyst", salary: 47000, status: "Inactive" }
  ]
};

function employeeReducer(state, action) {
  switch (action.type) {
    case "ADD_EMPLOYEE":
      return {
        ...state,
        employees: [...state.employees, action.payload],
      };

    case "UPDATE_EMPLOYEE":
      return {
        ...state,
        employees: state.employees.map((emp) =>
          emp.id === action.payload.id ? action.payload : emp
        ),
      };

    case "DELETE_EMPLOYEE":
      return {
        ...state,
        employees: state.employees.filter((emp) => emp.id !== action.payload),
      };

    default:
      return state;
  }
}

export const EmployeeProvider = ({ children }) => {
  const [state, dispatch] = useReducer(employeeReducer, initialState);

  const addEmployee = useCallback((employee) => {
    dispatch({
      type: "ADD_EMPLOYEE",
      payload: {
        ...employee,
        id: Date.now(),
      },
    });
  }, []);

  const updateEmployee = useCallback((employee) => {
    dispatch({
      type: "UPDATE_EMPLOYEE",
      payload: employee,
    });
  }, []);

  const deleteEmployee = useCallback((id) => {
    dispatch({
      type: "DELETE_EMPLOYEE",
      payload: id,
    });
  }, []);

  const value = useMemo(() => {
    return {
      employees: state.employees,
      addEmployee,
      updateEmployee,
      deleteEmployee,
    };
  }, [state.employees, addEmployee, updateEmployee, deleteEmployee]);

  return (
    <EmployeeContext.Provider value={value}>
      {children}
    </EmployeeContext.Provider>
  );
};

export const useEmployees = () => useContext(EmployeeContext);