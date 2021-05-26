
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
      console.log(data)
      console.log(data.status)
      if (data.status === 200) {
        // update UI
        // remove the form from the dom
        $(`#${this.id}`).parent().remove();
        // popup success
        alert(`Course removed from student.`);
      } else {
        alert("Delete failed. Please try again");
      }
    })
})

