import fs from 'fs';
import path from 'path';

export function buildFeedbackPath() {
    return path.join(process.cwd(), 'data', 'feedback.json');
}

export function extractFeedback(filePath){
    const fileData = fs.readFileSync(filePath);
    const data = JSON.parse(fileData);
    return data;
}

// NOT A REACT COMPONENT
function handler(req, res) {
if(req.method === 'POST'){
    const email = req.body.email;
    const feddbackText = req.body.text;

    const newFeedback = {
        id: new Date().toISOString(),
        email: email,
        text: feddbackText,
    };

    //^^^store that in a database or file
    const filePath = buildFeedbackPath();
    // read the file, than overwrite it
    const data = extractFeedback(filePath);
    data.push(newFeedback);
    fs.writeFileSync(filePath, JSON.stringify(data));
    res.status(201).json({message: 'Success!', feedback: newFeedback})
} else {
    const filePath = buildFeedbackPath();
    const data = extractFeedback(filePath);
    res.status(200).json({ feedback: data });

}
}

export default handler;
