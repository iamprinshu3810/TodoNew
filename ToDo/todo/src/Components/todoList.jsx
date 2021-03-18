import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import Todo from "./todo.jsx"
import "./todo.css";
import Form from "./form.jsx";
import FilterButton from "./filterButton.jsx";
import { fetchData }from "./constants.js";
let currentTab = 0;
const baseUrl = "https://localhost:5001";
let idToEdit = 0;
const ToDoList = () => {
  useEffect(() =>
  {
    getCurrentTodos();
  }, []);
 
 
  const [toDos, setTodos] = useState([]);
  const [isEditing, setEditing] = useState(false);
   
  function adjustTabChange()
  {
     if (currentTab == 0)
      {
        getCurrentTodos();
      }
      else if (currentTab == 1)
      {
        getPreviousTodos();
      }
      else
      {
        getComingTodos();
        }
  }
  function addToDo(name)
  {
    const url = baseUrl + "/User/CreateToDo";
    const userData = {
      userId: localStorage.getItem('userId'),
      toDo:name
    }
   fetchData(url, userData).then(data => {
        setTodos([...toDos, {
        toDo: name,
        status: "Pending"
      }]);
      })
    
  }
  function getCurrentTodos()
  {
     const url = baseUrl + "/User/GetTodayToDos"
     const userData = {
      userId:localStorage.getItem('userId')
    }
    fetchData(url,userData).then(todos => {
      setTodos(todos);
    })
    ;
  }
  function getPreviousTodos()
  {
     const url = baseUrl + "/User/GetPreviousToDos"
     const userData = {
      userId:localStorage.getItem('userId')
    }
    fetchData(url,userData).then(todos => {
      setTodos(todos);
    })
    ;
  }
  function getComingTodos()
  {
   
     const url = baseUrl + "/User/GetComingToDos"
     const userData = {
      userId:localStorage.getItem('userId')
    }
    fetchData(url,userData).then(todos => {
      setTodos(todos);
    })
    ;
  }
  function changeView(id)
  {
    if (id == "previous")
    {
       currentTab = 1;
      getPreviousTodos();
    }
    else if (id == "current")
    {
      currentTab =0;
      getCurrentTodos();
    }
    else
    {
       currentTab = 2;
      getComingTodos();
    }
  }
  function deleteTodo(id)
  {
    const url = baseUrl + "/User/DeleteToDo";
    const userData = {
      id:parseInt(id)
    }
    fetchData(url, userData).then(data => {
      adjustTabChange();
    })
  }
  function changeTodoState(id,isCompleted)
  {
    let url = baseUrl;
    if (!isCompleted) {
      url+= "/User/MarkToDo";
    }
    else
    {
      url+="/User/UnmarkToDo"
    }
     const userData = {
      id:parseInt(id)
    }
   fetchData(url, userData).then(data => {
      adjustTabChange();
    })
  }
  function editTodo(name)
  {
    const url = baseUrl + "/User/UpdateToDo";
    const userData={
      Id: idToEdit,
      newToDo:name  
    }
  fetchData(url, userData).then(data => {
      adjustTabChange();
      setEditing(false);
    })
  }
  function getTodoId(id)
  {
    idToEdit = id;
    setEditing(true);
  }
  return (
    <div className="todoapp stack-large">
      <h1>TodoMatic</h1>
      <Form addToDo={addToDo} editTodo={editTodo} isEditing={isEditing}/>
      <div className="filters btn-group stack-exception">    
        <FilterButton name={"Today's Task"} id={"current"} changeView={changeView}/>
        <FilterButton name={"Previous"} id={"previous"}  changeView={changeView}/>
        <FilterButton name={"Coming Up"} id={"coming"}  changeView={changeView}/>
      </div>
      <ul
        role="list"
        className="todo-list stack-large stack-exception"
        aria-labelledby="list-heading"
      >
        {toDos.map((todo) => (
          <Todo name={todo.toDo} key={todo.toDo} id={todo.id} completed={todo.status === "Pending" ? false : true} deleteTodo={deleteTodo} changeTodoState={changeTodoState} getTodoId={getTodoId}/>
        ))}
      </ul>
    </div>
  );
};
export default ToDoList;
