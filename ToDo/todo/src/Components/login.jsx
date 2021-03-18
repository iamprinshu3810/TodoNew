import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import{fetchLoginData} from "./constants"
import "bootstrap/dist/css/bootstrap.min.css";

const Login = () => {
  const [formData, setFormData] = useState({
    username: "",
    password: ""
  });
  const [isLogin, setLogin] = useState(false);
   let history = useHistory();
  const userData = {
    UserId: formData.username,
    Password: formData.password
  }
  const url = "https://localhost:5001/authentication";

  const formDataChangeHandler = (event) => {
    event.persist();
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    fetchLoginData(url,userData).then((data) => {
      localStorage.setItem('token', data.token);
      localStorage.setItem('userId', data.userId);
      history.push("/ToDo");
     });
  };
  return (
    <div className="container">
      <h1 className="mb-5"> Login ToDo List</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="username">UserName</label>
          <input
            type="text"
            name="username"
            value={formData.username}
            onChange={formDataChangeHandler}
            className="form-control"
            placeholder="Username"
          />
          <small className="form-text text-muted">
            We'll never share your email with anyone else.
          </small>
        </div>
        <div className="form-group">
          <label htmlFor="password">Password</label>
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={formDataChangeHandler}
            className="form-control"
            placeholder="Password"
          />
        </div>
        <button className="btn btn-success" type="submit">
          Login
        </button>
      </form>
    </div>
  );
};
export default Login;
