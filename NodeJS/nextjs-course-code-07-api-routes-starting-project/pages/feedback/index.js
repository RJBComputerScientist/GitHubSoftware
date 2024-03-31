import { useState } from "react";
import { buildFeedbackPath, extractFeedback } from "../api/feedback";

// REACT COMPONENT
function FeedbackPage(props) {
    const [feedbackData, setFeedbackData] = useState();
  function loadFeedbackHandler(id) {
    fetch(`/api/${id}`).then(response => response.json()).then(data => {
        setFeedbackData(data.feedback)
    }); //api/some-feedback-id
  }
  //^^^^^ Redundante code ^^^^^^ since you have the loaded feedback data already
  return (
    <>
    {feedbackData && <p>{feedbackData.email}</p>}
    <ul>
      {props.feedbackItems.map((item) => (
        <li key={item.id}>
          {item.text}{" "}
          <button onClick={loadFeedbackHandler.bind(null, item.id)}>Show Details</button>
        </li>
      ))}
    </ul>
    </>
  );
}

export async function getStaticProps() {
  // dont use "fetch()" with a API routes technique
  // use NodeJS modules to get the data.
  // REMEMBER, "getStaticProps()" & "getServerProps()" are about fetching and rendering data
  // ^^^ NOT responses.
  // REMEMBER code used in "getStaticProps()" & "getServerProps()", will not end up in the
  // ^^ client-side code bundle if its not being used in our client-side code
  const filePath = buildFeedbackPath();
  const data = extractFeedback(filePath);
  return {
    props: {
      feedbackItems: data,
    },
  };
}

export default FeedbackPage;
