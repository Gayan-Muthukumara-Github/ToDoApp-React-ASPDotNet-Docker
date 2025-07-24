import React, { useState } from 'react';

function TaskForm({ onAdd }) {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!title || !description) return;
    onAdd({ title, description });
    setTitle('');
    setDescription('');
  };

  return (
    <div>
      <h4>Add Task</h4>
      <form onSubmit={handleSubmit}>
        <div className="col-12 mb-3">
          <label className="form-label">Title</label>
          <input 
            type="text" 
            className="form-control" 
            value={title} 
            onChange={(e) => setTitle(e.target.value)} 
            required
          />
        </div>
        <div className="col-12 mb-3">
          <label className="form-label">Description</label>
          <textarea 
            className="form-control" 
            rows="3" 
            value={description} 
            onChange={(e) => setDescription(e.target.value)}
          ></textarea>
        </div>
        <div className="d-flex justify-content-end">
          <button type="submit" className="btn btn-sm btn-primary">
            Add
          </button>
        </div>
      </form>
    </div>
  );
}

export default TaskForm;
