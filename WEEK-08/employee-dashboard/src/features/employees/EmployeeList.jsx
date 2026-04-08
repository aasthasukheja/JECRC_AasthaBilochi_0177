import { useSelector, useDispatch } from "react-redux";
import { deleteEmployee } from "./employeeSlice";

function EmployeeList({ setEditData }) {
  const employees = useSelector((state) => state.employees.employees);
  const dispatch = useDispatch();

  return (
    <div className="grid">
      {employees.map((e) => (
        <div className="card" key={e.id}>
          <h4>{e.name}</h4>
          <p>{e.position}</p>

          <button onClick={() => setEditData(e)}>Edit</button>
          <button onClick={() => dispatch(deleteEmployee(e.id))}>
            Delete
          </button>
        </div>
      ))}
    </div>
  );
}

export default EmployeeList;