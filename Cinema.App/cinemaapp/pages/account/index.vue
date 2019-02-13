<template>
  <section class="section">
    <div class="container">
      <h2 class="title">Profil</h2>

      <div class="content">
       <div v-for='account in accounts' :key="account._id">

          <h1> {{ account.email }}</h1>
          <strong>Gatunek:  </strong> {{ account.username }}
          <strong>Date Time:  </strong> {{ account.role}}
          <strong>Date Time:  </strong> {{ account.email}}
           <br>
           <button><nuxt-link :to="{name:'account-id',params: { id:account._id }}" class="account">Szczegoły</nuxt-link></button>
          <br><br><br>
       </div>

      </div>


    </div>
  </section>
</template>
<script>
 import axios from 'axios'
 export default {
  data() {
    return {
      accounts:[]
    }
  },
  mounted() {
    var _this = this;
    axios.get('http://localhost:5000/account')
    .then (function(res){
      _this.accounts = res.data
      console.log('Data: ', res);

    })
    .catch( function(error){
      console.log('Error:' ,error);
    })
  }
}
</script>

