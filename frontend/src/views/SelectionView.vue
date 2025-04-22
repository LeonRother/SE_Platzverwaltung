<template>
  <div>
    <p>Choose a building and floor to show desks.</p>

    <input type="date" class="my-2 px-4 border border-gray-300" />

    <table class="w-full my-2 border border-gray-300">
      <thead class="bg-gray-50">
      <tr>
        <th class="w-1/2">
          Building
          <select
            class="w-24 mx-4 font-normal border"
            v-model="selectedBuilding"
            @change="onBuildingChange"
          >
            <option value="">—</option>
            <option v-for="building in buildings" :key="building.id" :value="building">
              {{ building.label }}
            </option>
          </select>
        </th>
        <th class="w-1/2">
          Floor
          <select
            class="w-24 mx-4 font-normal border"
            v-model="selectedFloor"
            @change="onFloorChange"
            :disabled="!floors"
          >
            <option value="">—</option>
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
          <button
            class="m-1 px-4 bg-sky-200 hover:bg-blue-300 active:bg-blue-400 rounded-full"
          >
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
      buildings: [],
      selectedBuilding: null,
      floors: [],
      selectedFloor: null,
      desks: [] // placeholder for future API integration
    };
  },
  methods: {
    async fetchBuildings() {
      try {
        const response = await axios.get('https://localhost:7000/building');
        this.buildings = response.data;
      } catch (error) {
        console.error('Error fetching buildings:', error);
        alert('Could not load buildings.');
      }
    },
    async onBuildingChange() {
      this.selectedFloor = null;
      this.floors = [];

      if (!this.selectedBuilding) return;

      try {
        const response = await axios.get(
          `https://localhost:7000/building/${this.selectedBuilding.id}/floors`
        );
        this.floors = response.data;
      } catch (error) {
        console.error('Error fetching floors:', error);
        alert('Could not load floors.');
      }
    },
    onFloorChange() {
      // TODO: fetch desks based on selected floor
      // axios.get(...).then(res => this.desks = res.data)
    }
  },
  mounted() {
    this.fetchBuildings();
  }
};
</script>
