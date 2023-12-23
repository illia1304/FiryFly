import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)
  const [error, setError] = useState()
  const [users, setusers] = useState([])
  useEffect(() => {
    fetch("http://localhost:5193/user", { method: "GET", mode: "no-cors"})
      .then(res => res.json())
      .then(j => setusers(j))
      .catch(e => setError(e));
  }, [])
  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
      { error && <h1>{error.toString()}</h1>}
      { !error &&
        <ul>
          {users.map(u => <h2>{u.toString()}</h2>)}
        </ul>
      }
      <h1>Hello World</h1>
    </>
  )
}

export default App
