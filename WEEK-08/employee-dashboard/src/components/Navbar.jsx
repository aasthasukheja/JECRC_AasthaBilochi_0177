import { useDispatch, useSelector } from "react-redux";
import { login, logout } from "../features/auth/authSlice";
import { toggleTheme } from "../features/ui/uiSlice";

function Navbar() {
  const dispatch = useDispatch();
  const { isLoggedIn } = useSelector((state) => state.auth);

  return (
    <div className="navbar">
      <h2>Employee Dashboard</h2>

      <div>
        <button onClick={() => dispatch(toggleTheme())}>🌙 Theme</button>

        {!isLoggedIn ? (
          <button onClick={() => dispatch(login())}>Login</button>
        ) : (
          <button onClick={() => dispatch(logout())}>Logout</button>
        )}
      </div>
    </div>
  );
}

export default Navbar;