import './App.css';
import MainLayout from './views/MainLayout'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import MainContent from './views/MainContent';


function App() {
  return (
    <BrowserRouter>
      <MainLayout>  
        <Routes>
          <Route exact path="/" element={<MainContent />} />
        </Routes>
      </MainLayout>  
    </BrowserRouter>
  );
}

export default App;
