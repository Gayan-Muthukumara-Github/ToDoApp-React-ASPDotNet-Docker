import React from 'react';

const TaskCard = ({ task, onDone }) => {
  return (
    <div className="card mb-3 bg-light">
      <div className="card-body">
        <h4 className="card-title">{task.title}</h4>

        <div className="d-flex justify-content-between align-items-center mt-2">
          <p className="card-text mb-0 flex-grow-1">{task.description}</p>
          <button 
            className="btn btn-sm btn-outline-secondary ms-3"
            onClick={() => onDone(task.id)}
          >
            Done
          </button>
        </div>
      </div>
    </div>
  );
};

export default TaskCard;
