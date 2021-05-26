
console.log($);

$("#deleteCourse").on("submit", function(event) {
  console.log("Delete Course clicked!");
  event.preventDefault();
  const courseId = this[0].value;
  const studentId = this[1].value;
  // send data via ajax to server
  // await response
  fetch(`http://localhost:5000/students/${studentId}/delete_course/${courseId}`)
    .then(response => response.json())
    .then(data => console.log(data))
  // update UI

})

