window.drawBudgetChart = (budget, expenses) => {
  var ctx = document.getElementById("budgetChart").getContext("2d");
  new Chart(ctx, {
      type: "bar",
      data: {
          labels: ["Budget", "Expenses"],
          datasets: [{
              label: "Amount",
              data: [budget, expenses],
              backgroundColor: ["green", "red"]
          }]
      }
  });
};

window.drawCategoryChart = (categoryData) => {
  var ctx = document.getElementById("categoryChart").getContext("2d");
  new Chart(ctx, {
      type: "pie",
      data: {
          labels: categoryData.map(c => c.category),
          datasets: [{
              data: categoryData.map(c => c.amount),
              backgroundColor: ["blue", "orange", "purple", "red", "yellow"]
          }]
      }
  });
};
