"use strict";
const validateEmail = (val) => (val === null || val === void 0 ? void 0 : val.indexOf("@")) !== -1 && (val === null || val === void 0 ? void 0 : val.indexOf(".")) !== -1;
const validateRequired = (val) => (val === null || val === void 0 ? void 0 : val.length) > 0;
const validateNumber = (val) => !Number.isNaN(Number.parseFloat(val));
const validateInt = (val) => !Number.isNaN(Number.parseInt(val));
const validateMinLength = (val, min) => (val === null || val === void 0 ? void 0 : val.length) >= min;
const validateMin = (val, min) => Number.parseFloat(val) >= min;
function deleteCourse(courseId) {
    if (confirm("Are you sure you want to delete this course?")) {
        $.ajax({
            url: '/Courses/' + courseId,
            type: 'DELETE',
            success: function (result) {
                window.location.href = "/Courses";
            }
        });
    }
}
function validateCourse() {
    const courseNumber = $("#courseNumber").val();
    const name = $("#name").val();
    const description = $("#description").val();
    if (!validateNumber(courseNumber)) {
        alert("Course Number must be a number");
        return false;
    }
    if (!validateMin(courseNumber, 1)) {
        alert("Course Number must grater than 0");
        return false;
    }
    if (!validateRequired(name)) {
        alert("Name is required");
        return false;
    }
    if (!validateRequired(description)) {
        alert("Description is required");
        return false;
    }
    return true;
}
function deleteInstructor(instructorId) {
    if (confirm("Are you sure you want to delete this instructor?")) {
        $.ajax({
            url: '/Instructors/' + instructorId,
            type: 'DELETE',
            success: function (result) {
                window.location.href = "/Instructors";
            }
        });
    }
}
function deleteStudent(studentId) {
    if (confirm("Are you sure you want to delete this student?")) {
        $.ajax({
            url: '/Students/' + studentId,
            type: 'DELETE',
            success: function (result) {
                window.location.href = "/Students";
            }
        });
    }
}
function validateInstructor() {
    const firstName = $("#firstName").val();
    const lastName = $("#lastName").val();
    const email = $("#email").val();
    const courseId = $("#courseId").val();
    if (!validateRequired(firstName)) {
        alert("First Name is required");
        return false;
    }
    if (!validateRequired(lastName)) {
        alert("Last Name is required");
        return false;
    }
    if (!validateEmail(email)) {
        alert("Email is not valid, must have @ and .");
        return false;
    }
    if (!validateInt(courseId)) {
        alert("Course must be selected.");
        return false;
    }
    if (!validateMin(courseId, 1)) {
        alert("Course Id must grater than 0");
        return false;
    }
    return true;
}
function validateStudent() {
    const firstName = $("#firstName").val();
    const lastName = $("#lastName").val();
    const email = $("#email").val();
    const phoneNumber = $("#phoneNumber").val();
    if (!validateRequired(firstName)) {
        alert("First Name is required");
        return false;
    }
    if (!validateRequired(lastName)) {
        alert("Last Name is required");
        return false;
    }
    if (!validateEmail(email)) {
        alert("Email is not valid, must have @ and .");
        return false;
    }
    if (!validateRequired(phoneNumber)) {
        alert("Phone Number is required");
        return false;
    }
    return true;
}
function editCourse(courseId, courseNumber, name, description) {
    $("#label").text("Edit Course");
    $("#courseId").val(courseId);
    $("#courseNumber").val(courseNumber);
    $("#name").val(name);
    $("#description").val(description);
    $("#submit").text("Update");
    $("#modal").modal("show");
}
function newCourse() {
    $("#label").text("Add Course");
    $("#courseId").val("");
    $("#courseNumber").val("");
    $("#name").val("");
    $("#description").val("");
    $("#submit").text("Create");
    $("#modal").modal("show");
}
function editInstructor(instructorId, firstName, lastName, email, courseId) {
    $("#label").text("Edit Instructor");
    $("#instructorId").val(instructorId);
    $("#firstName").val(firstName);
    $("#lastName").val(lastName);
    $("#email").val(email);
    $("#courseId").val(courseId);
    $("#submit").text("Update");
    $("#modal").modal("show");
}
function newInstructor() {
    $("#label").text("Add Instructor");
    $("#instructorId").val("");
    $("#firstName").val("");
    $("#lastName").val("");
    $("#email").val("");
    $("#courseId").val("");
    $("#submit").text("Create");
    $("#modal").modal("show");
}
function editStudent(studentId, firstName, lastName, email, phoneNumber) {
    $("#label").text("Edit Student");
    $("#studentId").val(studentId);
    $("#firstName").val(firstName);
    $("#lastName").val(lastName);
    $("#email").val(email);
    $("#phoneNumber").val(phoneNumber);
    $("#submit").text("Update");
    $("#modal").modal("show");
}
function newStudent() {
    $("#label").text("Add Student");
    $("#studentId").val("");
    $("#firstName").val("");
    $("#lastName").val("");
    $("#email").val("");
    $("#phoneNumber").val("");
    $("#submit").text("Create");
    $("#modal").modal("show");
}
