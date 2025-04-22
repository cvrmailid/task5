const fs = require('fs');
const path = require('path');

const dirPath = 'myDirectory';
const filePath = path.join(dirPath, 'hello.txt');

const data = 'Hello, this is a text file created using Node.js fs module!\n';

const appendData = 'This is some appended text.\n';


function createDirectoryAndFile() {
  if (!fs.existsSync(dirPath)) {
    fs.mkdir(dirPath, (err) => {
      if (err) {
        console.log('Error creating directory:', err);
        return;
      }
      console.log('Directory created successfully');
      
      createFile();
    });
  } else {
    console.log('Directory already exists');
    createFile();
  }
}

function createFile() {
  if (!fs.existsSync(filePath)) {
    fs.writeFile(filePath, data, (err) => {
      if (err) {
        console.log('Error creating file:', err);
        return;
      }
      console.log('File created successfully with data!');
      readFile();
    });
  } else {
    console.log('File already exists');
    readFile();
  }
}

function readFile() {
  fs.readFile(filePath, 'utf8', (err, content) => {
    if (err) {
      console.log('Error reading file:', err);
      return;
    }
    console.log('File content before appending:\n', content);
    
    appendToFile();
  });
}

function appendToFile() {
  fs.appendFile(filePath, appendData, (err) => {
    if (err) {
      console.log('Error appending to file:', err);
      return;
    }
    console.log('Data appended successfully!');
    readFileAgain();
  });
}
function readFileAgain() {
  fs.readFile(filePath, 'utf8', (err, content) => {
    if (err) {
      console.log('Error reading file:', err);
      return;
    }
    console.log('File content after appending:\n', content);
  });
}

createDirectoryAndFile();
