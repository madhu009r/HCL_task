const mealsDiv = document.getElementById("meals");
const mealName = document.getElementById("mealName");
const firstLetter = document.getElementById("firstLetter");
const categorySelect = document.getElementById("category");
const areaSelect = document.getElementById("area");

// Load categories & areas on page load
window.onload = () => {
    loadCategories();
    loadAreas();
};

// Load categories
function loadCategories() {
    fetch("https://www.themealdb.com/api/json/v1/1/list.php?c=list")
        .then(res => res.json())
        .then(data => {
            categorySelect.innerHTML = `<option value="">Select Category</option>`;
            data.meals.forEach(c => {
                categorySelect.innerHTML += `<option>${c.strCategory}</option>`;
            });
        });
}

// Load areas
function loadAreas() {
    fetch("https://www.themealdb.com/api/json/v1/1/list.php?a=list")
        .then(res => res.json())
        .then(data => {
            areaSelect.innerHTML = `<option value="">Select Area</option>`;
            data.meals.forEach(a => {
                areaSelect.innerHTML += `<option>${a.strArea}</option>`;
            });
        });
}

// Event listeners
mealName.onkeyup = searchMeals;
firstLetter.onkeyup = searchMeals;
categorySelect.onchange = filterByCategory;
areaSelect.onchange = filterByArea;

// Search by name or letter
function searchMeals() {
    let url = "";

    if (mealName.value) {
        url = `https://www.themealdb.com/api/json/v1/1/search.php?s=${mealName.value}`;
    } else if (firstLetter.value) {
        url = `https://www.themealdb.com/api/json/v1/1/search.php?f=${firstLetter.value}`;
    } else {
        mealsDiv.innerHTML = "";
        return;
    }

    fetch(url)
        .then(res => res.json())
        .then(data => displayMeals(data.meals));
}

// Filter by category
function filterByCategory() {
    fetch(`https://www.themealdb.com/api/json/v1/1/filter.php?c=${categorySelect.value}`)
        .then(res => res.json())
        .then(data => displayMeals(data.meals));
}

// Filter by area
function filterByArea() {
    fetch(`https://www.themealdb.com/api/json/v1/1/filter.php?a=${areaSelect.value}`)
        .then(res => res.json())
        .then(data => displayMeals(data.meals));
}

// Display meals
function displayMeals(meals) {
    mealsDiv.innerHTML = "";

    if (!meals) {
        mealsDiv.innerHTML = "<h4>No meals found</h4>";
        return;
    }

    meals.forEach(meal => {
        mealsDiv.innerHTML += `
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="${meal.strMealThumb}" class="card-img-top">
                    <div class="card-body">
                        <h5>${meal.strMeal}</h5>
                        <button class="btn btn-primary btn-sm"
                            onclick="getMealDetails('${meal.idMeal}')">
                            View Ingredients
                        </button>
                    </div>
                </div>
            </div>
        `;
    });
}

// Fetch ingredients
function getMealDetails(id) {
    fetch(`https://www.themealdb.com/api/json/v1/1/lookup.php?i=${id}`)
        .then(res => res.json())
        .then(data => {
            const meal = data.meals[0];
            let ingredients = "";

            for (let i = 1; i <= 20; i++) {
                if (meal[`strIngredient${i}`]) {
                    ingredients += `
                        <li>${meal[`strIngredient${i}`]} - ${meal[`strMeasure${i}`]}</li>`;
                }
            }

            alert(`Ingredients for ${meal.strMeal}:\n\n` +
                ingredients.replace(/<[^>]+>/g, ""));
        });
}
