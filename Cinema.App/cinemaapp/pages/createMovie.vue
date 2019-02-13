<template>
  <section class="section">
    <div class="container">
      <h2 class="title">Dodaj film</h2>
      <div class="content">
        <form method="post" @submit.prevent="create">
          <div class="field">
            <label class="label">Tytul</label>
            <input placeholder="tytul" type="title" class="input" name="title" v-model="title">
          </div>
          <div class="field">
            <label class="label">Opis</label>
            <input
              placeholder="opis"
              type="description"
              class="input"
              name="description"
              v-model="description"
            >
          </div>
          <div class="field">
            <label class="label">Gatuenk</label>
            <input placeholder="Gatunek" type="type" class="input" name="type" v-model="type">
          </div>
          <div class="field">
            <label class="label">Rezyser</label>
            <input
              placeholder="Rezyser"
              type="director"
              class="input"
              name="director"
              v-model="director"
            >
          </div>
          <div class="field">
            <label class="label">Producent</label>
            <input
              placeholder="Producent"
              type="producent"
              class="input"
              name="ptoducent"
              v-model="producer"
            >
          </div>
          <div class="field">
            <label class="label">Data</label>
            <input
              placeholder="Data"
              type="dateTime"
              class="input"
              name="dateTime"
              v-model="dateTime"
            >
          </div>

          <br>
          <button type="submit" class="btn btn-success">Success</button>
          <br>
          <br>
          <br>
          <br>
          <br>
        </form>
      </div>
    </div>
  </section>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      title: "",
      description: "",
      type: "",
      director: "",
      producer: "",
      dateTime: "",
      error: null
    };
  },
  methods: {
    create() {
      axios
        .post("http://localhost:5000/movies", {
          title: this.title,
          description: this.description,
          type: this.type,
          director: this.director,
          producer: this.producer,
          dateTime: this.dateTime
        })
        .then(function(res) {
          console.log("Data: ", res);
        })
        .catch(function(error) {
          console.log("Error:", error);
        });
    }
  }
};
</script>


