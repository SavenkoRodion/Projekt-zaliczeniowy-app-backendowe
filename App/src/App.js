import React, { useEffect, useState } from "react";
import Header from "./template/Header";
import Country from "./pages/Counrty/Country";
import Matches from "./pages/Matches/Matches";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";

const App = () => {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<></>} />
          <Route path="/about" element={<Country />} />
          <Route path="/contact" element={<Matches />} />
        </Routes>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/About">About</Link>
          </li>
          <li>
            <Link to="/Contact">Contact</Link>
          </li>
        </ul>
      </BrowserRouter>
    </>
  );
};

export default App;

/* <Header></Header>
<Routes>
    <Route path="/Matches">
      <Matches />
    </Route>
    <Route path="/Country">
      <Country />
    </Route>
  </Routes> */

//   <Router>
//   <div>
//     <h2>Welcome to React Router Tutorial</h2>
//     <nav className="navbar navbar-expand-lg navbar-light bg-light">
//       <ul className="navbar-nav mr-auto">
//         <li>
//           <Link to={"/"} className="nav-link">
//             {" "}
//             Home{" "}
//           </Link>
//         </li>
//         <li>
//           <Link to={"/lol"} className="nav-link">
//             Contact
//           </Link>
//         </li>
//       </ul>
//     </nav>
//     <hr />
//     <Routes>
//       <Route exact path="/" component={Country} />
//       <Route path="/lol" component={Matches} />
//     </Routes>
//   </div>
// </Router>
