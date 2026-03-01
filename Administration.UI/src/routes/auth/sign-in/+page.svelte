<script lang="ts">
	import { HugeiconsIcon } from '@hugeicons/svelte';
	import {
		Login01Icon,
		Settings04Icon,
		ViewIcon,
		ViewOffSlashIcon
	} from '@hugeicons/core-free-icons';

	let isPasswordVisible = $state<boolean>(false);
	const passwordInputType = $derived(isPasswordVisible ? 'text' : 'password');

	const changePasswordVisibility = () => {
		isPasswordVisible = !isPasswordVisible;
	};
</script>

<div class="relative min-h-screen w-full bg-white">
	<div class="auth-flow-background absolute inset-0 z-0 flex flex-col items-center justify-center">
		<div class="mb-20 flex items-center gap-4 text-4xl text-slate-700">
			<h3>Administration</h3>
			<HugeiconsIcon class="h-12 w-12" stroke="currentColor" icon={Settings04Icon} />
		</div>

		<div class="grid w-1/2 grid-cols-[1fr_1fr] items-center justify-center gap-10">
			<div class="flex h-full flex-col justify-center gap-6 border-r-2 border-slate-600 p-5">
				<h1 class="text-4xl font-medium text-slate-600">Sign In</h1>
				<p class="text-slate-500">
					Please sign in to access the management dashboard. From here, you can manage menus, track
					orders, and oversee staff performance
				</p>
			</div>

			<form class="mt-4 h-full flex-2 py-8">
				<div class="my-4 flex w-full flex-col">
					<label class="mb-2 font-medium text-amber-600" for="email">Email Address</label>
					<input
						type="email"
						name="email"
						class="text-md rounded-xl border-2 border-slate-400 bg-slate-100 px-4 py-3 font-medium text-slate-500 ring-0 outline-0 placeholder:text-slate-500 focus:border-black"
						placeholder="Enter your email address"
					/>
				</div>
				<div class="my-4 flex w-full flex-col">
					<label class="mb-2 font-medium text-amber-600" for="password">Password</label>
					<div class="relative">
						<input
							type={passwordInputType}
							class="text-md w-full rounded-xl border-2 border-slate-400 bg-slate-100 py-3 pr-16 pl-4 font-medium text-slate-500 ring-0 outline-0 placeholder:text-slate-500 focus:border-black"
							name="password"
							placeholder="Enter your password"
						/>
						{#if isPasswordVisible}
							<HugeiconsIcon
								class="absolute top-0 right-5 bottom-0 m-auto h-6 w-6 cursor-pointer text-slate-600"
								stroke="currentColor"
								onclick={changePasswordVisibility}
								icon={ViewIcon}
							/>
						{:else}
							<HugeiconsIcon
								class="absolute top-0 right-5 bottom-0 m-auto h-6 w-6 cursor-pointer text-slate-600"
								stroke="currentColor"
								strokeWidth={1.5}
								onclick={changePasswordVisibility}
								icon={ViewOffSlashIcon}
							/>
						{/if}
					</div>
				</div>
				<button
					class="mt-8 flex w-full cursor-pointer items-center justify-center gap-2 rounded-xl border-2 border-transparent bg-amber-300 px-4 py-3 text-slate-600 transition-colors duration-300 hover:bg-amber-500 hover:text-white"
				>
					<span class="h-full">Submit</span>
					<HugeiconsIcon icon={Login01Icon} stroke="currentColor" strokeWidth={2} class="h-6 w-6" />
				</button>
			</form>
		</div>
	</div>
</div>
