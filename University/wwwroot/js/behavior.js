
console.log("JS LOADED");

$(".deleteForm").on("submit", function(event) {
  console.log("Delete Course Form submitted!");
  event.preventDefault();
  console.log(this.id)
  const courseId = this[0].value;
  const studentId = this[1].value;
  // send data via ajax to server
  // await response
  const url = `/students/${studentId}/delete_course/${courseId}`;
  fetch(url, { method: 'POST' })
    .then(data => {
      if (data.status === 200) {
        // remove the form from the dom
        $(`#${this.id}`).parent().remove();
        alert(`Course removed from student.`);
      } else {
        alert("Delete failed. Please try again");
      }
    })
})

$(".deleteStudent").on("submit", function(event) {
  event.preventDefault();
  const courseStudentId = this[0].value;
  let url = `/courses/remove_student/${courseStudentId}`
  fetch(url, { method: 'POST' })
    .then(data => {
      if(data.status == 200) {
        $(`#${this.id}`).parent().parent().remove();
        alert(`Student removed from course`)
      } else {
        alert(`Student removal failed`)
      }
    })
})
