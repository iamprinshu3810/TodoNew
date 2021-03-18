import React from "react";
const Todo = (props) => {
    return (
        <li className="todo stack-small">
            <div className="c-cb">
                <input type="checkbox" defaultChecked={props.completed} onChange={() => props.changeTodoState(props.id,props.completed)} />
                <label className="todo-label" htmlFor="todo-0">
                    {props.name}
            </label>
            </div>
            <div className="btn-group">
                <button type="button" className="btn"onClick={()=>props.getTodoId(props.id)}>
                    Edit 
                </button>
                <button type="button" className="btn btn__danger" onClick={()=>props.deleteTodo(props.id)}>
                    Delete 
                </button>
            </div>
        </li>
    );
}
export default Todo;