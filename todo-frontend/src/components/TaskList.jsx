import React from 'react';
import TaskCard from './TaskCard';

const TaskList = ({ tasks, onDone }) => {
  return (
    <div>
      {tasks.length === 0 && <p className="text-muted">No tasks added yet.</p>}
      {tasks.map((task) => (
        <TaskCard key={task.id} task={task} onDone={onDone} />
      ))}
    </div>
  );
};

export default TaskList;
