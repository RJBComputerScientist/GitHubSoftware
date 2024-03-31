import { buildFeedbackPath, extractFeedback } from "./feedback";

function handler(req, res) {
    if(req.method === 'DELETE'){
        
    }
  const feedbackId = req.query.feedbackId;
  //                           ^^^ same name as filename in brackets
  const filePath = buildFeedbackPath();
  const feedbackData = extractFeedback(filePath);
  const selectedFeedbackId = feedbackData.find(
    (feedback) => feedback.id === feedbackId
  );
  res.status(200).json({ feedback: selectedFeedbackId });
}

export default handler;
