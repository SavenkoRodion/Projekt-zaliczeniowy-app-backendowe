import React, { useEffect, useState } from "react";
import ListGroup from "react-bootstrap/ListGroup";
import ListGroupItem from "react-bootstrap/ListGroupItem";

const Matches = () => {
  const [matches, setMatches] = useState([]);

  const fetchUserData = () => {
    fetch("https://localhost:7185/match/")
      .then((response) => {
        console.log(response);
        return response.json();
      })
      .then((data) => {
        setMatches(data);
        console.log(matches);
        console.log(matches.length);
        matches.forEach((match) => {
          console.log(match.homeTeam.name + "-" + match.homeTeam.name);
          console.log(Date.UTC(match.matchDate));
        });
      });
  };

  useEffect(() => {
    fetchUserData();
  }, []);

  return (
    <div>
      {matches.length > 0 && (
        <ListGroup>
          {matches.map((match) => (
            <ListGroupItem>
              {new Date(match.matchDate).getMonth()}.
              {new Date(match.matchDate).getDay()}{" "}
              {new Date(match.matchDate).getHours()}:
              {new Date(match.matchDate).getMinutes()} | {match.homeTeam.name} -{" "}
              {match.guestTeam.name}
            </ListGroupItem>
          ))}
        </ListGroup>
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
