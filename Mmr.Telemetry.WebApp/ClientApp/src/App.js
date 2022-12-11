import './App.css';
import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import {SidebarData} from './SidebarData';
import { Layout } from './components/Layout';
export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          {SidebarData.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}

// import './App.css';
// import Navbar from "./components/Navbar";
// import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
// import  Home   from './components/Home'
// function App() {
//   return (
//     <>
//         <Router>
//             <Navbar/>
//             <Routes>
//                 <Route path='/' exact component={Home}/>
//             </Routes>
//         </Router>
//     </>
//   );
// }

// export default App;

