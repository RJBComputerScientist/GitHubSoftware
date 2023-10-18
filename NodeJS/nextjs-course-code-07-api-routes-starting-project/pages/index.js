import { useRef, useState } from "react";

//A REACT COMPONENT
function HomePage() {
const [feedbackItems, setFeebackItems] = useState([]);

const emailInputRef = useRef();
const feedbackInputRef = useRef();

function submitFormHandler(event) {
  event.preventDefault();

  const enteredEmail = emailInputRef.current.value;
  const feedbackEmail = feedbackInputRef.current.value;

  const reqBody = {email: enteredEmail, text: feedbackEmail};

  fetch('/api/feedback', {
  //    ^^^ absolute path
    method: 'POST',
    body: JSON.stringify(reqBody),
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(response => response.json()).then(data => console.log(data));
}

function loadFeedbackHandler() {
  fetch('/api/feedback')
  .then(response => response.json())
  .then(data => {
    setFeebackItems(data.feedback)
  });
}

  return (
    <div>
      <h1>The Home Page</h1>
      <form>
        <div>
        <label htmlFor="email">Enter Email Address:</label>
        <input type="email" id="email" ref={emailInputRef} />
        </div>
        <div>
        <label htmlFor="feedback">Your Feedback:</label>
        <textarea type="text" id="feedback" rows={'5'} ref={feedbackInputRef} ></textarea>
        </div>
        <button onClick={submitFormHandler}>Send Feedback</button>
      </form>
      <hr />
      <button onClick={loadFeedbackHandler}>Load Feedback</button>
      <ul>
        {feedbackItems.map(item => <li key={item.id}>{item.text}</li>)}
      </ul>
    </div>
  );
}

export default HomePage;
