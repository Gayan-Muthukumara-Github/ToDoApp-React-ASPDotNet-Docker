import React, { useEffect, useState, useCallback } from 'react';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';

const API_URL = process.env.REACT_APP_API_URL || 'http://localhost:5000/api/tasks';

const App = () => {
  const [tasks, setTasks] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const fetchTasks = useCallback(async () => {
    setLoading(true);
    setError('');
    try {
      const res = await fetch(API_URL);
      if (!res.ok) throw new Error('Failed to fetch tasks');
      const data = await res.json();
      setTasks(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }, []);

  const addTask = useCallback(async (task) => {
    setError('');
    try {
      const res = await fetch(API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(task),
      });
      if (!res.ok) throw new Error('Failed to add task');
      fetchTasks();
    } catch (err) {
      setError(err.message);
    }
  }, [fetchTasks]);

  const markAsDone = useCallback(async (id) => {
    setError('');
    try {
      const res = await fetch(`${API_URL}/${id}/complete`, { method: 'PUT' });
      if (!res.ok) throw new Error('Failed to mark as done');
      fetchTasks();
    } catch (err) {
      setError(err.message);
    }
  }, [fetchTasks]);

  useEffect(() => {
    fetchTasks();
  }, [fetchTasks]);

  return (
    <div className="container border mt-4 p-4 shadow-sm bg-white rounded">
      {error && <div className="alert alert-danger">{error}</div>}
      {loading ? (
        <div>Loading...</div>
      ) : (
        <div className="row">
          <div className="col-md-6 border-end">
            <TaskForm onAdd={addTask} />
          </div>
          <div className="col-md-6">
            <TaskList tasks={tasks} onDone={markAsDone} />
          </div>
        </div>
      )}
    </div>
  );
};

export default App;
