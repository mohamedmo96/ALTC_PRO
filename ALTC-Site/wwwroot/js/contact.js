function showForm(formId) {
  const forms = document.querySelectorAll('.form-wrapper');
  forms.forEach(form => {
    if (form.id === formId) {
      // Toggle the max-height of the selected form
      if (form.style.maxHeight) {
        form.style.maxHeight = null;
      } else {
        form.style.maxHeight = form.scrollHeight + "px";
      }
    } else {
      // Hide other forms by setting their max-height to 0
      form.style.maxHeight = null;
    }
  });
}
