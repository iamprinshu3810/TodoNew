import React, { useState, useEffect } from "react";
const FilterButton = (props) => {
  function handleButtonClick(event)
  {
    console.log(event);
  }
    return (
      <button onClick={()=>props.changeView(props.id)} id={props.id}type="button" className="btn toggle-btn" aria-pressed="true">
      <span className="visually-hidden">Show </span>
      <span>{props.name} </span>
      <span className="visually-hidden"> tasks</span>
    </button>
  );
}
export default FilterButton;