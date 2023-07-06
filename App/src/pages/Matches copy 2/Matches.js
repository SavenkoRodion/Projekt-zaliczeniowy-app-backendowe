// import React, { useEffect, useState } from "react"

// const Matches = () => {
//   const [users, setUsers] = useState([])

//   const fetchUserData = () => {
//     fetch("https://localhost:7185/country/all")
//       .then(response => {
//         console.log(response)
//         return response.json()
//       })
//       .then(data => {
//         setUsers(data)
//       })
//   }

//   useEffect(() => {
//     fetchUserData()
//   }, [])

//   return (
//     <div>
//       {users.length > 0 && (
//         <ul>
//           {users.map(user => (
//             <li key={user.id}>{user.name}</li>
//           ))}
//         </ul>
//       )}
//     </div>
//   );
// }

// export default Matches;