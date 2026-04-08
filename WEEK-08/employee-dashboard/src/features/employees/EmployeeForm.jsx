import { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { addEmployee, updateEmployee } from "./employeeSlice";
import { setLoading } from "../ui/uiSlice";

function EmployeeForm({ editData, setEditData }) {
  const [name, setName] = useState("");
  const [position, setPosition] = useState("");
  const dispatch = useDispatch();

  useEffect(() => {
    if (editData) {
      setName(editData.name);
      setPosition(editData.position);
    }
  }, [editData]);

  const handleSubmit = () => {
    dispatch(setLoading(true));

    setTimeout(() => {
      if (editData) {
        dispatch(updateEmployee({ id: editData.id, name, position }));
        setEditData(null);
      } else {
        dispatch(
          addEmployee({
            id: Date.now(),
            name,
            position,
          })
        );
      }

      setName("");
      setPosition("");
      dispatch(setLoading(false));
    }, 500);
  };

  return (
    <div className="card">
      <h3>{editData ? "Edit Employee" : "Add Employee"}</h3>
      <input value={name} onChange={(e) => setName(e.target.value)} placeholder="Name" />
      <input value={position} onChange={(e) => setPosition(e.target.value)} placeholder="Position" />
      <button onClick={handleSubmit}>
        {editData ? "Update" : "Add"}
      </button>
    </div>
  );
}

export default EmployeeForm;