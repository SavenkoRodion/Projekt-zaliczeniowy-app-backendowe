import React, { useEffect, useState } from "react";

const Matches = () => {
  const [matches, setMatches] = useState([]);

  const fetchUserData = () => {
    fetch("https://localhost:7185/match/all")
      .then((response) => {
        console.log(response);
        return response.json();
      })
      .then((data) => {
        setMatches(data);
        console.log(matches);
        console.log(matches.length);
        matches.forEach((match) =>
          console.log(match.homeTeam.name + "-" + match.homeTeam.name)
        );
      });
  };

  useEffect(() => {
    fetchUserData();
  }, []);

  return (
    <div>
      lolek
      {matches.length > 0 && (
        <ul>
          {matches.map((match) => (
            <li>
              {match.homeTeam.name} - {match.guestTeam.name}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Matches;

// {matches.forEach((match) => (
//   <li key={match.id}>
//     {match.homeTeam.name} {match.homeTeam.name}
//   </li>
// ))}
