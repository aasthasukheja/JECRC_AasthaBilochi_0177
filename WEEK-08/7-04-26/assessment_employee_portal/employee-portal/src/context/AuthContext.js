import React, { createContext, useContext, useMemo, useState, useCallback } from "react";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const login = useCallback((username) => {
    if (!username.trim()) return false;
    setUser({ name: username });
    return true;
  }, []);

  const logout = useCallback(() => {
    setUser(null);
  }, []);

  const value = useMemo(() => {
    return {
      user,
      isAuthenticated: !!user,
      login,
      logout,
    };
  }, [user, login, logout]);

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => useContext(AuthContext);