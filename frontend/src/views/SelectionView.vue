<template>
  <div>
    <p>Choose a building and floor to show desks.</p>

    <input type="date" class="my-2 px-4 border border-gray-300">
    <table class="w-full my-2 border border-gray-300">
      <thead class="bg-gray-50">
        <tr>
          <th class="w-1/2">Building
            <select class="w-16 mx-4 font-normal border" @change="updateFloorSelection()" v-model="selectedBuilding">
              <option value=""></option>
              <option v-for="building in buildings" :key="building.id" :value="building">
                {{ building.label }}
              </option>
            </select>
          </th>
          <th class="w-1/2">Floor
            <select class="w-16 mx-4 font-normal border" @change="updateTable()" v-model="selectedFloor">
              <option value=""></option>
              <option v-for="floor in floors" :key="floor.id" :value="floor">
                {{ floor.label }}
              </option> 
            </select>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="desk in desks" :key="desk.id" class="text-center">
          <td class="border border-gray-300" colspan="2">
            {{ desk.label }}
            <button class="m-1 px-4 bg-sky-200 hover:bg-blue-300 active:bg-blue-400 rounded-full" @click="bookDesk(desk.id)">
              Book
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'SelectionView',
  data() {
    return {
      buildings: null,
      selectedBuilding: null,
      floors: null,
      selectedFloor: null,
      desks: []
    }
    
  },
  methods: {
    fetchBuildings() {
      axios.get('https://localhost:7000/building')
      .then(res => {
        this.buildings = res.data;
      })
      .catch(error => {
        document.getElementById('message').innerText = error;
        console.error('Error fetching building data:', error);
      });
    },
    updateFloorSelection() {
      axios.get('https://localhost:7000/building/' + this.selectedBuilding.id + '/floors')
      .then(res => {
        this.floors = res.data;
        
      });
    },
    updateTable() {
      // TODO: update table here
      // - api call /
      
      axios.get('https://localhost:7000/floors/' + this.selectedFloor.id + '/desks')
        .then(res => {
          this.desks = res.data;
        })
        .catch(err => {
          console.error("Error fetching desks:", err);
        });
    },
    bookDesk(deskId){
      const dateInput = document.querySelector('input[type="date"]');
      const selectedDate = dateInput?.value;

      if (!selectedDate) {
      alert("Please select a date first.");
      return;
      }
      axios.post('https://localhost:7000/building/book-desk',{
        deskId: deskId,
        date: selectedDate,
        userId: 1
      })
      .then(()=>{
        alert("Desk booked succesfully");
      })
      .catch(err => {
      if (err.response && err.response.status === 409) {
        alert("Desk already booked for this date.");
      } else {
        alert("Error booking desk.");
        console.error(err);
      }
    })
    }
  },
  
  mounted() {
    this.fetchBuildings();
  }
}
</script>
